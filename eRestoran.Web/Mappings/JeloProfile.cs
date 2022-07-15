using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using eRestoran.Web.Areas.Administrator.Models;

namespace eRestoran.Web.Mappings
{
    public class JeloProfile : Profile
    {
        public JeloProfile()
        {
            CreateMap<JeloUpsert, JeloUpsertRequest>();
            CreateMap<JeloResponse, JeloUpsert>();
            CreateMap<JeloResponse, Jelo>();
            CreateMap<object, Jelo>();
        }
    }
}
