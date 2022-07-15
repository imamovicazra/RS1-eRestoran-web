using eRestoran.Contracts.Responses;

namespace eRestoran.Web.Areas.Administrator.Models
{
    public class UposlenikPrikaz
    {
        public PagedResponse<KorisnikResponse> Content { get; set; }

        public string Search { get; set; }
    }
}
