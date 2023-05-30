using System;

namespace SecurityAPI.Domain.Exceptions
{
    public class UserExistsException : ArgumentException
    {
        public UserExistsException(string message)
            : base(message)
        {
        }
    }
}