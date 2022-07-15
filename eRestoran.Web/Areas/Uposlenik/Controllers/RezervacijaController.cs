using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Uposlenik.Controllers
{
    [Area("Uposlenik")]
    [Authorization(Administrator: false, Uposlenik: true, Korisnik: false)]
    public class RezervacijaController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;

        public RezervacijaController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var paginationQuery = new PaginationQuery(page, 10);
            var response = await _restoranApi.GetRezervacijaAsync(null, paginationQuery);
            return View(response.Content);
        }

        public async Task<IActionResult> RezervacijaOdobri(int id)
        {
            var response = await _restoranApi.UpdateRezervacijaAsync(id);
            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> RezervacijaOdbij(int id)
        {
            await _restoranApi.DeleteRezervacijaAsync(id);
            return Redirect(nameof(Index));
        }
    }
}
