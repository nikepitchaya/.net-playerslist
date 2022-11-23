﻿using System;

namespace PlayersList.ExceptionBase
{
    public class BaseException : Exception
    {
        public string code { get; set; }
        public string message { get; set; }

        public BaseException(string code, string message)
        { 
            this.code = code;
            this.message = message;
        }
    }
}
