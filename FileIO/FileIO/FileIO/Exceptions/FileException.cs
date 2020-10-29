using System;
using System.Collections.Generic;
using System.Text;

namespace FileIO.Exceptions
{
    public class FileException : Exception
    {
        public FileException(string message) : base(message) { }
    }
}
