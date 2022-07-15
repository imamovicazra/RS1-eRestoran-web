using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using eRestoran.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeloController : CrudController<JeloResponse, JeloSearchRequest, JeloUpsertRequest, JeloUpsertRequest>
    {
        private readonly IJeloService _service;
        public JeloController(IJeloService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public override Task<ActionResult<PagedResponse<JeloResponse>>> Get([FromQuery] JeloSearchRequest search, [FromQuery] PaginationQuery pagination)
        {
            return base.Get(search, pagination);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public override Task<ActionResult<JeloResponse>> GetById(int id)
        {
            return base.GetById(id);
        }

        [HttpPost("{id}/Like")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<JeloResponse>> Like(int id)
        {
            var KorisnikID = HttpContext.GetUserID();

            if (KorisnikID == null)
            {
                return BadRequest();
            }

            var response = await _service.Like(id, (int)KorisnikID);

            if (!response)
            {
                return BadRequest(response);
            }

            PathString path = HttpContext.Request.Path;
            return Created(path, response);
        }

        [HttpDelete("{id}/Like")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<JeloResponse>> Dislike(int id)
        {
            var KorisnikID = HttpContext.GetUserID();

            if (KorisnikID == null)
            {
                return BadRequest();
            }

            var response = await _service.Dislike(id, (int)KorisnikID);

            if (!response)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
