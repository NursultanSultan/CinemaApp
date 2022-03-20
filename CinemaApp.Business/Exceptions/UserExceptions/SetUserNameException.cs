using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.Exceptions.UserExceptions
{
    public class SetUserNameException : UserException
    {
        public SetUserNameException(string message) : base(message)
        {

        }
    }
}
