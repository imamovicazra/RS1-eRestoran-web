using AutoMapper;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;

namespace eRestoran.WebApi.Mappings
{
    public class UlogaProfil : Profile
    {
        public UlogaProfil()
        {
            CreateMap<Uloga, UlogaResponse>();
        }
    }
}
