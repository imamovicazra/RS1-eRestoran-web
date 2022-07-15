using AutoMapper;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;

namespace eRestoran.Services
{
    public class StatusDostaveService : BaseService<StatusDostaveResponse, object, StatusDostave>
    {
        public StatusDostaveService(eRestoranContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
