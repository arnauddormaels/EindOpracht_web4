﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary.Models
{
    public class ErrorSource
    {
            public ErrorSource(string className, string methodName)
            {
                ClassName = className;
                MethodName = methodName;
            }
            public string ClassName { get; set; }
            public string MethodName { get; set; }

            public override bool Equals(object? obj)
            {
                return obj is ErrorSource source &&
                       ClassName == source.ClassName &&
                       MethodName == source.MethodName;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(ClassName, MethodName);
            }

            public override string ToString()
            {
                return $"(Class:{ClassName},Method:{MethodName})";
            }
        }
}
