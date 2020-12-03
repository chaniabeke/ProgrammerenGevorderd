using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Exceptions
{
    public class OrderManagerException : Exception
    {
        public OrderManagerException(string message) : base(message)
        {
        }

        public OrderManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
