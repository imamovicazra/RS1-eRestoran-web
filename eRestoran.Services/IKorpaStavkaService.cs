using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface IKorpaStavkaService:ICrudService<KorpaStavkaResponse,KorpaStavkaSearchRequest,KorpaStavkaUpsertRequest,KorpaStavkaUpsertRequest>
    {
        Task<bool> OcistiKorpu(string KorpaID);
    }
}
