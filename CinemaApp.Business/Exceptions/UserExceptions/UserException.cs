using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.Exceptions.UserExceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) { }
    }
}
