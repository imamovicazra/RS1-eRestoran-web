using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Helpers
{
    public class JwtParser
    {
        public static JwtSecurityToken Parse(string jsonWebToken)
        {
            var jwt = jsonWebToken;
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);


            return token;
        }
    }
}
