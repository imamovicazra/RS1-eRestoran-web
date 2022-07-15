﻿using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace eRestoran.WebApi.Extensions
{
    public static class GeneralExtensions
    {
        public static int? GetUserID(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return null;
            }

            return Convert.ToInt32(httpContext.User.Claims.Single(x => x.Type == "id").Value);
        }
    }
}
