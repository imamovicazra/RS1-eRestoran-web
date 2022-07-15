using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Services;
using Microsoft.AspNetCore.Authorization;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using eRestoran.Domain;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorpaStavkaController : CrudController<KorpaStavkaResponse, KorpaStavkaSearchRequest, KorpaStavkaUpsertRequest, KorpaStavkaUpsertRequest>
    {
        private readonly IKorpaStavkaService _service;
        public KorpaStavkaController(IKorpaStavkaService service) : base(service)
        {
            _service = service;
        }

        

        [HttpGet]
        [AllowAnonymous]
        public override Task<ActionResult<PagedResponse<KorpaStavkaResponse>>> Get([FromQuery] KorpaStavkaSearchRequest search, [FromQuery] PaginationQuery pagination)
        {
            return base.Get(search, pagination);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public override Task<ActionResult<KorpaStavkaResponse>> GetById(int id)
        {
            return base.GetById(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public override Task<ActionResult<KorpaStavkaResponse>> Insert(KorpaStavkaUpsertRequest request)
        {
            return base.Insert(request);
        }        

        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        [AllowAnonymous]
        public override Task<ActionResult<KorpaStavkaResponse>> Update(int id, [FromBody] KorpaStavkaUpsertRequest request)
        {
            return base.Update(id, request);
        }

        [HttpDelete("{KorpaID}/Stavke")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> OcistiKorpu(string KorpaID)
        {
            var response = await _service.OcistiKorpu(KorpaID);

            if (!response)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
