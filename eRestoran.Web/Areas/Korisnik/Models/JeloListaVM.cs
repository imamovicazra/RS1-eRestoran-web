using eRestoran.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Korisnik.Models
{
    public class JeloListaVM
    {
        
        public PagedResponse<JeloResponse> Content { get; set; }
        public string TrenutnaKategorija { get; set; }
        public string Search { get; set; }
        public string kateg { get; set; }
    }
}
