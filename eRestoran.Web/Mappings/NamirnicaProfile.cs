using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Web.Areas.Uposlenik.Models;

namespace eRestoran.Web.Mappings
{
    public class NamirnicaProfile : Profile
    {
        public NamirnicaProfile()
        {
            CreateMap<NamirnicaResponse, NamirnicaUpsert>();
            CreateMap<NamirnicaUpsert, NamirnicaUpsertRequest>();
        }
    }
}
