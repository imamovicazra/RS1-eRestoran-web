using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Domain;

namespace eRestoran.Web.Mappings
{
    public class KorpaStavkaProfile:Profile
    {
        public KorpaStavkaProfile()
        {

            CreateMap<KorpaStavkaResponse, KorpaStavka>();
            CreateMap<KorpaStavka, KorpaStavkaUpsertRequest>();
            CreateMap<KorpaStavkaResponse, KorpaStavka>();
        }

    }
}
