using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Models
{
    public class JeloPrikazVM
    {
        public PagedResponse<JeloResponse> Content { get; set; }
        public string TrenutnaKategorija { get; set; }
        public string Search { get; set; }
        public string kateg { get; set; }
    }
}
