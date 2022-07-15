using eRestoran.Contracts.Responses;
using System.Collections.Generic;

namespace eRestoran.Web.Areas.Uposlenik.Models
{
    public class NarudzbePrikaz
    {
        public PagedResponse<NarudzbaResponse> Narudzbe { get; set; }
        public string Search { get; set; } = "";
    }
}
