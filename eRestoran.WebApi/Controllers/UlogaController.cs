using eRestoran.Contracts.Responses;
using eRestoran.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlogaController : BaseController<UlogaResponse, object>
    {
        public UlogaController(IBaseService<UlogaResponse, object> service) : base(service)
        {
        }
    }
}
