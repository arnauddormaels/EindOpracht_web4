
using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging.Exceptions
{
    public class DomainModelException : BLException
    {
        public Error Error { get; set; }

        public DomainModelException(string? message) : base(message)
        {
        }
    }
}
