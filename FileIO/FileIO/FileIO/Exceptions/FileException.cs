using System;

namespace FileIO.Exceptions
{
    public class FileException : Exception
    {
        public FileException(string message) : base(message)
        {
        }
    }
}