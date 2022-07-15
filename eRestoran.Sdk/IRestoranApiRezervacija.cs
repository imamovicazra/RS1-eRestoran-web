using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Refit;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    public partial interface IRestoranApi
    {
        [Get("/api/Rezervacija")]
        Task<ApiResponse<PagedResponse<RezervacijaResponse>>> GetRezervacijaAsync(object request = default, PaginationQuery pagination = default);

        [Get("/api/Rezervacija/{id}")]
        Task<ApiResponse<GradResponse>> GetRezervacijaByIdAsync(int id);

        [Post("/api/Rezervacija")]
        Task<ApiResponse<GradResponse>> CreateRezervacijaAsync([Body] RezervacijaInsertRequest request);

        [Patch("/api/Rezervacija/{id}")]
        Task<ApiResponse<GradResponse>> UpdateRezervacijaAsync(int id);

        [Delete("/api/Rezervacija/{id}")]
        Task<ApiResponse<bool>> DeleteRezervacijaAsync(int id);
    }
}
