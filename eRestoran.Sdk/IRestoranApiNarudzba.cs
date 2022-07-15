using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    public partial interface IRestoranApi
    {
        [Get("/api/Narudzba")]
        Task<ApiResponse<PagedResponse<NarudzbaResponse>>> GetNarudzbaAsync(NarudzbaSearchRequest request = default, PaginationQuery pagination = default);

        [Get("/api/Narudzba/{id}")]
        Task<ApiResponse<NarudzbaResponse>> GetNarudzbaByIdAsync(int id);

        [Get("/api/StatusDostave")]
        Task<ApiResponse<PagedResponse<StatusDostaveResponse>>> GetStatusDostaveAsync();

        [Post("/api/Narudzba")]
        Task<ApiResponse<NarudzbaResponse>> CreateNarudzbaAsync(NarudzbaInsertRequest request);

        [Put("/api/Narudzba/{id}")]
        Task<ApiResponse<NarudzbaResponse>> UpdateNarudzbaAsync(int id, NarudzbaUpdateRequest request);

        [Put("/api/Narudzba/{id}")]
        Task<ApiResponse<NarudzbaResponse>> UpdateNarudzbaAsync(int id, NarudzbaInsertRequest request);

        [Delete("/api/Narudzba/{id}")]
        Task<ApiResponse<bool>> DeleteNarudzbaAsync(int id);

        [Get("/api/Narudzba/{id}/Detalji")]
        Task<ApiResponse<List<NarudzbaDetaljiResponse>>> GetDetaljiAsync(int id);

        [Patch("/api/Narudzba/{id}/Status/{statusID}")]
        Task<ApiResponse<NarudzbaResponse>> UpdateStatusAsync(int id, int statusID);

        #region NarudzbaDetalji
        [Get("/api/NarudzbaDetalji")]
        Task<ApiResponse<PagedResponse<NarudzbaDetaljiResponse>>> GetNarudzbaDetaljiAsync(NarudzbaDetaljiSearchRequest request = default, PaginationQuery pagination = default);

        [Get("/api/NarudzbaDetalji/{id}")]
        Task<ApiResponse<NarudzbaDetaljiResponse>> GetNarudzbaDetaljiByIdAsync(int id);

        [Post("/api/NarudzbaDetalji")]
        Task<ApiResponse<NarudzbaDetaljiResponse>> CreateNarudzbaDetaljiAsync(NarudzbaDetaljiUpsertRequest request);

        [Put("/api/NarudzbaDetalji/{id}")]
        Task<ApiResponse<NarudzbaDetaljiResponse>> UpdateNarudzbaDetaljiAsync(int id, NarudzbaDetaljiUpsertRequest request);

        [Delete("/api/NarudzbaDetalji/{id}")]
        Task<ApiResponse<bool>> DeleteNarudzbaDetaljiAsync(int id);
        #endregion
    }
}
