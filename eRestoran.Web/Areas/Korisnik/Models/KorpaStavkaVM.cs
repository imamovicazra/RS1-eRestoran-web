using eRestoran.Contracts.Responses;
using System.Collections.Generic;

namespace eRestoran.Web.Areas.Korisnik.Models
{
    public class KorpaStavkaVM
    {
        public List<KorpaStavkaResponse> KorpaStavke { get; set; }
        public double KorpaUkupno { get; set; }
    }
}
