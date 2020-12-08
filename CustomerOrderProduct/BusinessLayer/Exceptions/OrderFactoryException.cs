using System;

namespace BusinessLayer.Exceptions
{
    public class OrderFactoryException : Exception
    {
        public OrderFactoryException(string message) : base(message)
        {
        }

        public OrderFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}