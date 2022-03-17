using CinemaApp.Business.Exceptions.ImageException;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.Exceptions.FileExceptions
{
    public class FileTypeException : FileException
    {
        public FileTypeException(string message) : base(message)
        {

        }
    }
}
