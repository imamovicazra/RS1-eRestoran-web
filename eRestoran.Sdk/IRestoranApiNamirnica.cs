using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Refit;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    public partial interface IRestoranApi
    {
        [Get("/api/Namirnica")]
        Task<ApiResponse<PagedResponse<NamirnicaResponse>>> GetNamirnicaAsync(NamirnicaSearchRequest filter, PaginationQuery paginationQuery);

        [Get("/api/Namirnica/{id}")]
        Task<ApiResponse<NamirnicaResponse>> GetNamirnicaByIdAsync(int id);

        [Post("/api/Namirnica")]
        Task<ApiResponse<NamirnicaResponse>> CreateNamirnicaAsync([Body] NamirnicaUpsertRequest request);

        [Put("/api/Namirnica/{id}")]
        Task<ApiResponse<NamirnicaResponse>> UpdateNamirnicaAsync(int id, [Body] NamirnicaUpsertRequest request);

        [Delete("/api/Namirnica/{id}")]
        Task<ApiResponse<bool>> DeleteNamirnicaAsync(int id);
    }
}
