using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Web.Areas.Administrator.Models;
using eRestoran.Web.Areas.Korisnik.Models;

namespace eRestoran.Web.Mappings
{
    public class KorisnikProfile : Profile
    {
        public KorisnikProfile()
        {
            CreateMap<KorisnikResponse, KorisnikDetalji>();
            CreateMap<KorisnikResponse, AdminDetaljiIzmjena>();
            CreateMap<AdminDetaljiIzmjena, KorisnikUpdateInfoRequest>();
            CreateMap<KorisnikDetaljiIzmjenaVM, KorisnikUpdateInfoRequest>();
            CreateMap<KorisnikResponse, KorisnikDetaljiIzmjenaVM>();
            CreateMap<KorisnikResponse, UposlenikDetalji>();
        }
    }
}
