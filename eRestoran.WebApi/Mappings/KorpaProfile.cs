using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;

namespace eRestoran.WebApi.Mappings
{
    public class KorpaProfile:Profile
    {
        public KorpaProfile()
        {
            CreateMap<KorpaStavkaUpsertRequest, KorpaStavka>();
            CreateMap<KorpaStavka, KorpaStavkaResponse>();
        }
    }
}
