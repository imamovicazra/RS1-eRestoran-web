using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eRestoran.Web.Helpers
{
    public interface IKorpaHelper
    {
        
        public Task DodajUKorpuAsync(Jelo jelo, int kolicina);
        public Task<int> UkloniIzKorpeAsync(Jelo jelo);
        public Task<List<KorpaStavkaResponse>> GetStavkeAsync();
        public Task IzbrisiStavkeAsync();
        public Task<double> UkupnoAsync();
    }
}
