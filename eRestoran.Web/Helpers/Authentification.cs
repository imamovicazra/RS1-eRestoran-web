using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Helpers
{
    public static class Authentification
    {
        private static readonly string Key = "token";
        public static void SetJwt(this HttpContext context, string value)
        {
            context.Response.SetCookieJson(Key, value);
        }

        public static string GetJwt(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(Key);
        }

        public static void DeleteJwt(this HttpContext context)
        {
            context.Response.RemoveCookie(Key);
        }
    }
}
