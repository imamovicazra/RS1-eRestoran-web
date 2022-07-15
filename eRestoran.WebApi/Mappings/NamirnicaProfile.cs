using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;

namespace eRestoran.WebApi.Mappings
{
    public class NamirnicaProfile : Profile
    {
        public NamirnicaProfile()
        {
            CreateMap<Namirnica, NamirnicaResponse>();
            CreateMap<NamirnicaUpsertRequest, Namirnica>();
        }
    }
}
