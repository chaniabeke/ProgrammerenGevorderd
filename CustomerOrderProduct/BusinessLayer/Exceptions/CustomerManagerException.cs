using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Exceptions
{
    public class CustomerManagerException : Exception
    {
        public CustomerManagerException(string message) : base(message)
        {
        }

        public CustomerManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
