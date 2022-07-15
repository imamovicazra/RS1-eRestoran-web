using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eRestoran.Sdk
{
    [Headers("Authorization: Bearer")]
    public partial interface IRestoranApi
    {
        #region Kategorija
        [Get("/api/Kategorija")]
        Task<ApiResponse<PagedResponse<KategorijaResponse>>> GetKategorijaAsync(KategorijaSearchRequest request = default, PaginationQuery pagination = default);
        [Get("/api/Kategorija/{id}")]
        Task<ApiResponse<KategorijaResponse>> GetKategorijaByIdAsync(int id);
        #endregion

        #region Korisnik
        [Get("/api/Korisnik")]
        Task<ApiResponse<PagedResponse<KorisnikResponse>>> GetKorisnikAsync(KorisnikSearchRequest request = default, PaginationQuery pagination = default);
        [Get("/api/Korisnik/{id}")]
        Task<ApiResponse<KorisnikResponse>> GetKorisnikByIdAsync(int id);

        [Put("/api/Korisnik/{id}")]
        Task<ApiResponse<KorisnikResponse>> UpdateKorisnikAsync(int id, KorisnikUpdateRequest request);

        [Delete("/api/Korisnik/{id}")]
        Task<ApiResponse<bool>> DeleteKorisnikAsync(int id);

        [Post("/api/Korisnik/LicneInformacije")]
        Task<ApiResponse<KorisnikResponse>> LicneInformacije([Query] KorisnikUpdateInfoRequest request);

        [Post("/api/Korisnik/ChangePassword")]
        Task<ApiResponse<dynamic>> ChangePassword(ChangePasswordRequest request);

        [Get("/api/Korisnik/me")]
        Task<ApiResponse<KorisnikResponse>> Me();
        [Get("/api/Korisnik/Jela")]
        Task<ApiResponse<List<JeloResponse>>> Jela();
        #endregion

        #region Uloga
        [Get("/api/Uloga")]
        Task<ApiResponse<PagedResponse<UlogaResponse>>> GetUlogaAsync();
        #endregion
       

    }
}
