namespace API.Middleware
{
    public static class LogMiddlewareExtention
    {

        public static IApplicationBuilder UseResponseServiceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseServiceMiddleware>();
        }
    }
}
