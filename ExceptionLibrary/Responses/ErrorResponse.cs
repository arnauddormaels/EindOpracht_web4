using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging.Responses
{
    public abstract class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ErrorResponse(int statusCode, string message)
        {
            Message = message;
            StatusCode = statusCode;
        }

    }
}
