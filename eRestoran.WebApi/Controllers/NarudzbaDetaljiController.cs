using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    public class NarudzbaDetaljiController : CrudController<NarudzbaDetaljiResponse, NarudzbaDetaljiSearchRequest, NarudzbaDetaljiUpsertRequest, NarudzbaDetaljiUpsertRequest>
    {
        public NarudzbaDetaljiController(ICrudService<NarudzbaDetaljiResponse, NarudzbaDetaljiSearchRequest, NarudzbaDetaljiUpsertRequest, NarudzbaDetaljiUpsertRequest> service) : base(service)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public override Task<ActionResult<PagedResponse<NarudzbaDetaljiResponse>>> Get([FromQuery] NarudzbaDetaljiSearchRequest search, [FromQuery] PaginationQuery pagination)
        {
            return base.Get(search, pagination);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public override Task<ActionResult<NarudzbaDetaljiResponse>> GetById(int id)
        {
            return base.GetById(id);
        }
    }
}

