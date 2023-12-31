﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareExceptionsAndLogging.Models
{
    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public List<PropertyInfo> Values { get; set; } = new List<PropertyInfo>();
        public override string ToString()
        {
            return $"(Message:{Message},Properties:{string.Join('|', Values)})";
        }
    }
}
