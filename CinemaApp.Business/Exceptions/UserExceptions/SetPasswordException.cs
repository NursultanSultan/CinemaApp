using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.Exceptions.UserExceptions
{
    public class SetPasswordException : UserException
    {
        public SetPasswordException(string message):base(message)
        {
        }
    }
}
