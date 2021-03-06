﻿using System;

namespace BusinessLayer.Exceptions
{
    public class ProductManagerException : Exception
    {
        public ProductManagerException(string message) : base(message)
        {
        }

        public ProductManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}