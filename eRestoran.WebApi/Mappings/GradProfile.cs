using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;

namespace eRestoran.WebApi.Mappings
{
    public class GradProfile : Profile
    {
        public GradProfile()
        {
            CreateMap<Grad, GradResponse>();
            CreateMap<GradUpsertRequest, Grad>();
        }
    }
}
