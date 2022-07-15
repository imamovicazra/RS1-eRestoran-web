using eRestoran.Contracts.Requests;
using eRestoran.Domain;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface IAuthService
    {
        Task<AuthenticationResult> RegisterAsync(RegisterRequest request);

        Task<AuthenticationResult> LoginAsync(LoginRequest request);

        Task<AuthenticationResult> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
