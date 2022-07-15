using eRestoran.Web.Store;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace eRestoran.Web.Handlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IAuthTokenStore _authTokenStore;

        public AuthHeaderHandler(IAuthTokenStore authTokenStore) 
        {
            _authTokenStore = authTokenStore;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _authTokenStore.GetToken();

            //potentially refresh token here if it has expired etc.
            
            request.Headers.Add("Accept", "application/json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
