using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using eRestoran.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : CrudController<KorisnikResponse, KorisnikSearchRequest, object, KorisnikUpdateRequest>
    {
        private readonly IKorisnikService _service;
        public KorisnikController(IKorisnikService service) : base(service)
        {
            _service = service;
        }
       
        [HttpGet]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public override Task<ActionResult<PagedResponse<KorisnikResponse>>> Get([FromQuery] KorisnikSearchRequest search, [FromQuery] PaginationQuery pagination)
        {
            return base.Get(search, pagination);
        }

        [HttpPost(nameof(LicneInformacije))]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<KorisnikResponse>> LicneInformacije([FromQuery] KorisnikUpdateInfoRequest request)
        {
            var ID = Convert.ToInt32(HttpContext.GetUserID());
            var response = await _service.UpdateLicneInformacije(ID, request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost(nameof(ChangePassword))]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<dynamic>> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var ID = HttpContext.GetUserID();

            if (ID == null)
            {
                return BadRequest();
            }

            var response = await _service.ChangePassword((int)ID, request);

            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Succeeded);
        }

        [HttpGet("me")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<KorisnikResponse>> Me()
        {
            var ID = HttpContext.GetUserID();

            if(ID == null)
            {
                return BadRequest();
            }

            var response = await _service.GetById((int)ID);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        [HttpGet("Jela")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public async Task<ActionResult<KorisnikResponse>> Jela()
        {
            var ID = HttpContext.GetUserID();

            if (ID == null)
            {
                return BadRequest();
            }

            var response = await _service.GetLajkanaJela((int)ID);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

    }
}
