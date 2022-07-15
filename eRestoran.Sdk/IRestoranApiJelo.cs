using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Refit;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    public partial interface IRestoranApi
    {
        [Get("/api/Jelo")]
        Task<ApiResponse<PagedResponse<JeloResponse>>> GetJeloAsync(JeloSearchRequest request = default, PaginationQuery pagination = default);

        [Get("/api/Jelo/{id}")]
        Task<ApiResponse<JeloResponse>> GetJeloByIdAsync(int id);

        [Post("/api/Jelo")]
        Task<ApiResponse<JeloResponse>> CreateJeloAsync(JeloUpsertRequest request);

        [Put("/api/Jelo/{id}")]
        Task<ApiResponse<JeloResponse>> UpdateJeloAsync(int id, JeloUpsertRequest request);

        [Delete("/api/Jelo/{id}")]
        Task<ApiResponse<bool>> DeleteJeloAsync(int id);

        [Post("/api/Jelo/{id}/Like")]
        Task<ApiResponse<bool>> Like(int id);

        [Delete("/api/Jelo/{id}/Like")]
        Task<ApiResponse<bool>> Dislike(int id);
    }
}
