using MiddlewareExceptionsAndLogging.Exceptions;
using MiddlewareExceptionsAndLogging.Responses;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace API.Middleware
{
    public class ResponseServiceMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger requestLogger;
        private readonly ILogger domainExceptionLogger;
        private readonly ILogger infrastructureExceptionLogger;
        private string requestBody;

        public ResponseServiceMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            requestLogger = loggerFactory.CreateLogger("RequestLogging");
            domainExceptionLogger = loggerFactory.CreateLogger("DomainExceptionLogging");
            infrastructureExceptionLogger = loggerFactory.CreateLogger("InfrastructureLogger");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();

                using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    requestBody = await reader.ReadToEndAsync();
                    requestBody = requestBody.Replace("\n", string.Empty).Replace("\t", string.Empty);

                    context.Request.Body.Seek(0, SeekOrigin.Begin);
                }
                await next(context);
            }
            catch (DomainModelException ex)
            {
                await ProcessDomainError(ex, context);
            }
            catch (InfrastructureException ex)
            {
                await ProcessInfrastructureException(ex, context);
            }catch(ServiceException ex)
            {
                await ProcessServiceError(ex, context);
            }catch(Exception ex)
            {
                throw new Exception("Unkown Error");
            }
            finally
            {
                requestLogger.LogInformation(
                    "Request {method} {url} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }

        private async Task ProcessInfrastructureException(InfrastructureException ex, HttpContext context)
        {
            infrastructureExceptionLogger.LogError("Infrascturecture Error"
                + "\n\t[" + string.Join('|', GetExptionMessages(ex)) + "]"
                + "\n\t[" + string.Join('|', ex.Sources) + "]"
                );

            var errorResponse = new InfrastructureErrorResponse(500,"Infrastructure Error");
            var json = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(json);

                }

        public async Task ProcessDomainError(DomainModelException ex, HttpContext context)
        {
            domainExceptionLogger.LogError("DomainException "
                + "\n\t[" + string.Join('|', GetExptionMessages(ex)) + "]"
                + "\n\t[" + string.Join('|', ex.Sources) + "]"
                + "\n\t[" + ex.Error.ToString() + "]"
                );

            var errorResponse = new DomainErrorResponse(400, "Domain Error",ex.Error);
            var json = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(json);
        }
        public async Task ProcessServiceError(ServiceException ex, HttpContext context)
        {
            domainExceptionLogger.LogError("ServiceException "
                + "\n\t[" + string.Join('|', GetExptionMessages(ex)) + "]"
                + "\n\t[" + string.Join('|', ex.Sources) + "]"
                + "\n\t[" + ex.Error.ToString() + "]"
                + "\n\t[" + context.Request?.Path.Value + "]"
                + "\n\t[" + context.Request?.Method + "]"
                + "\n\t[" + requestBody+ "]"

                );

            var errorResponse = new ServiceErrorResponse(400, "Service Error", ex.Error
                ,context.Request?.Path.Value, context.Request?.Method, requestBody);
            var json = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(json);
        }





        private List<string> GetExptionMessages(Exception ex)
        {
            List<string> messages = new List<string>();

            while (ex != null)
            {
                messages.Add(ex.Message);
                ex = ex.InnerException;
            }
            return messages;
        }
    }
}
