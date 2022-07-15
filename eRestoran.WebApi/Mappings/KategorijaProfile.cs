using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Mappings
{
    public class KategorijaProfile : Profile
    {
        public KategorijaProfile()
        {
            CreateMap<Kategorija, KategorijaResponse>();
            CreateMap<KategorijaUpsertRequest, Kategorija>();
        }
    }
}
