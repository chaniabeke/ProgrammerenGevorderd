using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Exceptions
{
    public class CustomerFactoryException : Exception
    {
        public CustomerFactoryException(string message) : base(message)
        {
        }

        public CustomerFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
