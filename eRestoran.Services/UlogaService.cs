using AutoMapper;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;

namespace eRestoran.Services
{
    public class UlogaService : BaseService<UlogaResponse, object, Uloga>
    {
        public UlogaService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
