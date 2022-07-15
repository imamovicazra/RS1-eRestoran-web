using AutoMapper;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Mappings
{
    public class KategorijaProfile:Profile
    {
        public KategorijaProfile()
        {
            CreateMap<KategorijaResponse, Kategorija>();
        }
    }
}
