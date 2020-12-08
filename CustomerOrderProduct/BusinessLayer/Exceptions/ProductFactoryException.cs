using System;

namespace BusinessLayer.Exceptions
{
    public class ProductFactoryException : Exception
    {
        public ProductFactoryException(string message) : base(message)
        {
        }

        public ProductFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}