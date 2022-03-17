using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.Exceptions.ImageException
{
    public class FileException : Exception
    {
        public FileException(string message) : base(message) { }
    }
}
