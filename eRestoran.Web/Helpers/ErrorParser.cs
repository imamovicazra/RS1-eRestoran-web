using Newtonsoft.Json.Linq;
using System;

namespace eRestoran.Web.Helpers
{
    public static class ErrorParser
    {
        public static string Parse(string errors)
        {
            var error = new String("");

            if(errors != null)
            {
                errors = errors.Trim('\"');
                var objects = JObject.Parse(errors);
                foreach (var root in objects)
                {
                    foreach (var values in root.Value)
                    {
                        error += values + "\n";
                    }

                }
            }

            return error;
        }
    }
}
