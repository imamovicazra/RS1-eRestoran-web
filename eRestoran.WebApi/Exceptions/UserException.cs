﻿using System;

namespace eRestoran.WebApi.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }
}
