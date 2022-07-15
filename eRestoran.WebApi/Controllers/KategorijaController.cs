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
    public class KategorijaController : CrudController<KategorijaResponse, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        public KategorijaController(ICrudService<KategorijaResponse, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest> service) : base(service)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public override Task<ActionResult<PagedResponse<KategorijaResponse>>> Get([FromQuery] KategorijaSearchRequest search, [FromQuery] PaginationQuery pagination)
        {
            return base.Get(search, pagination);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public override Task<ActionResult<KategorijaResponse>> GetById(int id)
        {
            return base.GetById(id);
        }
    }
}
