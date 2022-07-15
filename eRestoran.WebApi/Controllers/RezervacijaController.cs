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
    public class RezervacijaController : BaseController<RezervacijaResponse, object>
    {
        private readonly IRezervacijaService _service;
        public RezervacijaController(IRezervacijaService service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<RezervacijaResponse>> Insert(RezervacijaInsertRequest request)
        {
            var ID = HttpContext.GetUserID();

            if (ID == null)
            {
                return BadRequest();
            }


            var response = await _service.Insert((int)ID, request);
            if (response == null)
            {
                return BadRequest();
            }

            PathString path = HttpContext.Request.Path;
            return Created(path, response);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Administrator, Uposlenik")]
        public async Task<ActionResult<RezervacijaResponse>> Update(int id)
        {
            var korisnikID = HttpContext.GetUserID();

            if (korisnikID == null)
            {
                return BadRequest();
            }

            var response = await _service.Update(id, (int)korisnikID);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, Uposlenik")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var response = await _service.Delete(id);

            if (response == false)
            {
                return NoContent();
            }

            return Ok(response);
        }
    }
}
