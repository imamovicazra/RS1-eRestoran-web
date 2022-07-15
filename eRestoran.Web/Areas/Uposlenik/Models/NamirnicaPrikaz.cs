using eRestoran.Contracts.Responses;

namespace eRestoran.Web.Areas.Uposlenik.Models
{
    public class NamirnicaPrikaz
    {
        public PagedResponse<NamirnicaResponse> Content { get; set; }

        public string Search { get; set; }
    }
}
