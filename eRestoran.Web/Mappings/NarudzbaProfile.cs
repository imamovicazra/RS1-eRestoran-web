using AutoMapper;
using eRestoran.Contracts.Responses;
using eRestoran.Web.Areas.Uposlenik.Models;

namespace eRestoran.Web.Mappings
{
    public class NarudzbaProfile : Profile
    {
        public NarudzbaProfile()
        {
            CreateMap<NarudzbaResponse, NarudzbaUredi>();
        }
    }
}
