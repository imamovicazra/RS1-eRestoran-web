using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    public partial interface IRestoranApi
    {
        [Get("/api/KorpaStavka")]
        Task<ApiResponse<PagedResponse<KorpaStavkaResponse>>> GetKorpaStavkaAsync(KorpaStavkaSearchRequest request = default, PaginationQuery pagination = default);

        [Get("/api/KorpaStavka/{id}")]
        Task<ApiResponse<KorpaStavkaResponse>> GetKorpaStavkaByIdAsync(int id);

        [Post("/api/KorpaStavka")]
        Task<ApiResponse<KorpaStavkaResponse>> CreateKorpaStavkaAsync(KorpaStavkaUpsertRequest request);

        [Put("/api/KorpaStavka/{id}")]
        Task<ApiResponse<KorpaStavkaResponse>> UpdateKorpaStavkaAsync(int id, KorpaStavkaUpsertRequest request);

        [Delete("/api/KorpaStavka/{id}")]
        Task<ApiResponse<bool>> DeleteKorpaStavkaAsync(int id);

        [Delete("/api/KorpaStavka/{KorpaID}/Stavke")]
        Task<ApiResponse<bool>> OcistiKorpu(string KorpaID);
    }
}
