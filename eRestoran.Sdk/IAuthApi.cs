using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Refit;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    public interface IAuthApi
    {
        [Post("/api/Auth/Register")]
        Task<ApiResponse<AuthSuccessResponse>> RegisterAsync([Body] RegisterRequest registrationRequest);

        [Post("/api/Auth/Login")]
        Task<ApiResponse<AuthSuccessResponse>> LoginAsync([Body] LoginRequest loginRequest);

        [Post("/api/Auth/Refresh")]
        Task<ApiResponse<AuthSuccessResponse>> RefreshAsync([Body] RefreshTokenRequest refreshRequest);

    }
}
