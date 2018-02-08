using System;
using System.Collections.Generic;
using System.Text;

namespace AluraTestDrive.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
