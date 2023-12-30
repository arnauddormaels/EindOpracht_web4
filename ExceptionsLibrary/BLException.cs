using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary.ErrorModels
{
    public class BLException : Exception
    {
        public List<ErrorSource> Sources { get; set; } = new List<ErrorSource>();

        public BLException(string? message) : base(message)
        {
            
        }
    }
}
