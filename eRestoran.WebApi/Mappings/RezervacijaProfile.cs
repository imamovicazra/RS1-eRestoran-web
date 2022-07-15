using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;

namespace eRestoran.WebApi.Mappings
{
    public class RezervacijaProfile : Profile
    {
        public RezervacijaProfile()
        {
            CreateMap<RezervacijaInsertRequest, Rezervacija>();
            CreateMap<Rezervacija, RezervacijaResponse>();
        }
    }
}
