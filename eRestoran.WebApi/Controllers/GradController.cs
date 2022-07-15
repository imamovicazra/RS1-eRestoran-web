using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eRestoran.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradController : CrudController<GradResponse, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>
    {
        public GradController(ICrudService<GradResponse, GradSearchRequest, GradUpsertRequest, GradUpsertRequest> service) : base(service)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<ActionResult<PagedResponse<GradResponse>>> Get([FromQuery] GradSearchRequest search, [FromQuery] PaginationQuery pagination)
        {
            return await base.Get(search, pagination);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public override Task<ActionResult<GradResponse>> GetById(int id)
        {
            return base.GetById(id);
        }
    }
}
