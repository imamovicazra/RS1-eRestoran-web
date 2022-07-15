using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface IRezervacijaService : IBaseService<RezervacijaResponse, object>
    {
        Task<RezervacijaResponse> Insert(int korisnikID, RezervacijaInsertRequest request);
        Task<RezervacijaResponse> Update(int id, int korisnikID);
        Task<bool> Delete(int id);
    }
}
