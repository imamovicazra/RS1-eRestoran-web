using System.Threading.Tasks;
using eRestoran.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICrudService<T, TSearch, TInsert, TUpdate> _service = null;
        public CrudController(ICrudService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public virtual async Task<ActionResult<T>> Insert(TInsert request)
        {
            var response = await _service.Insert(request);
            if (response == null)
            {
                return BadRequest();
            }

            PathString path = HttpContext.Request.Path;
            return Created(path, response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, Uposlenik,Korisnik")]
        public virtual async Task<ActionResult<T>> Update(int id, [FromBody] TUpdate request)
        {
            var response = await _service.Update(id, request);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, Uposlenik, Korisnik")]
        public virtual async Task<ActionResult<bool>> Delete(int id)
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
