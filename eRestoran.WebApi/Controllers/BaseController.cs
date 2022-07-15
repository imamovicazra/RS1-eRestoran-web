using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController<T, TSearch> : ControllerBase
    {
        private readonly IBaseService<T, TSearch> _service;

        public BaseController(IBaseService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public virtual async Task<ActionResult<PagedResponse<T>>> Get([FromQuery] TSearch search, [FromQuery] PaginationQuery pagination)
        {
            var response = await _service.Get(search, pagination);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public virtual async Task<ActionResult<T>> GetById(int id)
        {
            var response = await _service.GetById(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
