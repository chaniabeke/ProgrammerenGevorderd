using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandelingOef
{
    internal class CustomCatError : ApplicationException
    {
        public CustomCatError()
        {
        }

        public CustomCatError(string message) : base(message)
        {
        }

        public CustomCatError(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
