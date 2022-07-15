using System.Collections.Generic;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using eRestoran.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NarudzbaController : BaseController<NarudzbaResponse, NarudzbaSearchRequest>
    {
        private readonly INarudzbaService _service;
        public NarudzbaController(INarudzbaService service) : base(service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public override Task<ActionResult<PagedResponse<NarudzbaResponse>>> Get([FromQuery] NarudzbaSearchRequest search, [FromQuery] PaginationQuery pagination)
        {
            return base.Get(search, pagination);
        }

        [HttpGet("{id}/Detalji")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<List<NarudzbaDetaljiResponse>>> GetDetalji(int id)
        {
            var list = await _service.GetDetalji(id);

            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]

        public async Task<ActionResult<NarudzbaResponse>> Insert(NarudzbaInsertRequest request)
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]

        public async Task<ActionResult<NarudzbaResponse>> Update(int id, NarudzbaUpdateRequest request)
        {
            var response = await _service.Update(id, request);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPatch("{id}/Status/{statusID}")]
        [Authorize(Roles = "Administrator, Uposlenik")]
        public async Task<ActionResult<NarudzbaResponse>> UpdateStatus(int id, int statusID)
        {
            var korisnikID = HttpContext.GetUserID();

            if (korisnikID == null)
            {
                return BadRequest();
            }

            var response = await _service.UpdateStatusDostave(id, (int)korisnikID, statusID);

            if(response == null)
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
