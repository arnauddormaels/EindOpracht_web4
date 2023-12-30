using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging.Responses
{
    public class ServiceErrorResponse : ErrorResponse
    {
        public string Body;
        public string Method;
        public string Uri;
        public Error Error { get; set; }

        public ServiceErrorResponse(int statusCode, string message, Error error, string? uri, string? method, string requestBody) : base(statusCode, message)
        {
            Error = error;
            Body = requestBody;
            Method = method;
            Uri = uri;

        }
    }
}
