﻿namespace PlayersList.ExceptionBase
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message) : base("000002", message)
        {
        }
    }
}
