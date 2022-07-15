using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Refit;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    public partial interface IRestoranApi
    {
        [Get("/api/Grad")]
        Task<ApiResponse<PagedResponse<GradResponse>>> GetGradAsync(GradSearchRequest request = default, PaginationQuery pagination = default);

        [Get("/api/Grad/{id}")]
        Task<ApiResponse<GradResponse>> GetGradByIdAsync(int id);

        [Post("/api/Grad")]
        Task<ApiResponse<GradResponse>> CreateGradAsync([Body] GradUpsertRequest request);

        [Put("/api/Grad/{id}")]
        Task<ApiResponse<GradResponse>> UpdateGradAsync(int id, [Body] GradUpsertRequest request);

        [Delete("/api/Grad/{id}")]
        Task<ApiResponse<bool>> DeleteGradAsync(int id);
    }
}
