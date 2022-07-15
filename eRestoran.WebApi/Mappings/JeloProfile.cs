using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using System.Collections.Generic;

namespace eRestoran.WebApi.Mappings
{
    public class JeloProfile : Profile
    {
        public JeloProfile()
        {
            CreateMap<Jelo, JeloResponse>();
            CreateMap<JeloUpsertRequest, Jelo>();
            CreateMap<Kategorija, KategorijaResponse>();
            CreateMap<JeloResponse, Jelo>();
            
        }
    }
}
