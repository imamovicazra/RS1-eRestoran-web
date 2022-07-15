using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public interface INarudzbaService : 
        IBaseService<NarudzbaResponse, NarudzbaSearchRequest>
    {
        public Task<List<NarudzbaDetaljiResponse>> GetDetalji(int id);
        public Task<NarudzbaResponse> UpdateStatusDostave(int id, int korisnikID, int statusID);

        public Task<NarudzbaResponse> Insert(int korisnikID, NarudzbaInsertRequest request);
        public Task<NarudzbaResponse> Update(int id, NarudzbaUpdateRequest request);
        public Task<bool> Delete(int id);
    }
}
