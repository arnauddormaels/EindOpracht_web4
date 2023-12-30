using MiddlewareExceptionsAndLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging
{
    public class BLException : Exception
    {
        public List<ErrorSource> Sources { get; set; } = new List<ErrorSource>();

        public BLException(string? message) : base(message)
        {
            
        }

        public BLException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
