using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging.Responses
{
    public class DomainErrorResponse : ErrorResponse
    {
        public Error Error { get; set; }
        public DomainErrorResponse(int statusCode, string message, Error error) : base(statusCode, message)
        {
            Error = error;
        }
    }
}
