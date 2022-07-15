using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;

namespace eRestoran.WebApi.Mappings
{
    public class NarudzbaProfile : Profile
    {
        public NarudzbaProfile()
        {
            CreateMap<Narudzba, NarudzbaResponse>();
            CreateMap<NarudzbaInsertRequest, Narudzba>();
            CreateMap<NarudzbaUpdateRequest, Narudzba>();
            CreateMap<StatusDostave, StatusDostaveResponse>();
            CreateMap<NarudzbaDetalji, NarudzbaDetaljiResponse>();
            CreateMap<NarudzbaDetaljiUpsertRequest, NarudzbaDetalji>();
        }
    }
}
