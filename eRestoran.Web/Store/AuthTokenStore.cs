using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Http;

namespace eRestoran.Web.Store
{
    public class AuthTokenStore : IAuthTokenStore
    { 
        private readonly IHttpContextAccessor _httpContext;

        public AuthTokenStore(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetToken()
        {
            return _httpContext.HttpContext.GetJwt();
        }
    }
}
