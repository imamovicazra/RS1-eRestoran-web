using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface IKorisnikService : ICrudService<KorisnikResponse, KorisnikSearchRequest, object, KorisnikUpdateRequest>
    {
        public Task<KorisnikResponse> UpdateLicneInformacije(int ID, KorisnikUpdateInfoRequest request);
        public Task<IdentityResult> ChangePassword(int ID, ChangePasswordRequest request);
        public Task<List<JeloResponse>> GetLajkanaJela(int id);
        
    }
}
