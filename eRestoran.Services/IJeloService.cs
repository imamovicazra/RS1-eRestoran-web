using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface IJeloService : ICrudService<JeloResponse, JeloSearchRequest, JeloUpsertRequest, JeloUpsertRequest>
    {
        public Task<bool> Like(int JeloID, int KorisnikID);
        public Task<bool> Dislike(int JeloID, int KorisnikID);
    }
}
