using eRestoran.Contracts.Responses;
using eRestoran.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusDostave : BaseController<StatusDostaveResponse, object>
    {
        public StatusDostave(IBaseService<StatusDostaveResponse, object> service) : base(service)
        {
        }
    }
}
