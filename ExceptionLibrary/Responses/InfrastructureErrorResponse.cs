using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging.Responses
{
    public class InfrastructureErrorResponse : ErrorResponse
    {
        public InfrastructureErrorResponse(int statusCode, string message) : base(statusCode, message)
        {
        }
    }
}
