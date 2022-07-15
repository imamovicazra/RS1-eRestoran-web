using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using System.Collections.Generic;

namespace eRestoran.WebApi.Mappings
{
    public class KorisnikProfile : Profile
    {
        public KorisnikProfile()
        {
            CreateMap<RegisterRequest, Korisnik>();
            CreateMap<Korisnik, KorisnikResponse>();
            CreateMap<KorisnikUpdateRequest, Korisnik>();
            
        }
    }
}
