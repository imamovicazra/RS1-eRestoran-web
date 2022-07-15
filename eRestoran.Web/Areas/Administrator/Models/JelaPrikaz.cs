using eRestoran.Contracts.Responses;

namespace eRestoran.Web.Areas.Administrator.Models
{
    public class JelaPrikaz
    {
        public PagedResponse<JeloResponse> Content { get; set; }
        
        public string Search { get; set; }
    }
}
