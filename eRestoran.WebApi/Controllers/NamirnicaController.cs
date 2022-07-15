using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Services;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamirnicaController : CrudController<NamirnicaResponse, NamirnicaSearchRequest, NamirnicaUpsertRequest, NamirnicaUpsertRequest>
    {
        public NamirnicaController(ICrudService<NamirnicaResponse, NamirnicaSearchRequest, NamirnicaUpsertRequest, NamirnicaUpsertRequest> service) : base(service)
        {
        }
    }
}
