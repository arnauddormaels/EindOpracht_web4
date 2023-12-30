using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging.Exceptions
{
    public class InfrastructureException : BLException
    {
        public InfrastructureException(string? message) : base(message)
        {
        }
    }
}
