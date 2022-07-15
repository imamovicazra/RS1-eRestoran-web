using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Areas.Uposlenik.Models;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Uposlenik.Controllers
{
    [Area("Uposlenik")]
    [Authorization(Administrator: false, Uposlenik: true, Korisnik: false)]
    public class NarudzbaController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;

        public NarudzbaController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            
            var request = new NarudzbaSearchRequest()
            {
                Adresa = search
            };

            var paginationQuery = new PaginationQuery(page, 10);
            var narudzbeResponse = await _restoranApi.GetNarudzbaAsync(request, paginationQuery);

            var model = new NarudzbePrikaz()
            {
                Narudzbe = narudzbeResponse.Content
            };

            return View(model);
        }

        public async Task<IActionResult> NarudzbaUredi(int id)
        {
            var response = await _restoranApi.GetNarudzbaByIdAsync(id);
            var detaljiResponse = await _restoranApi.GetDetaljiAsync(id);

            var model = _mapper.Map<NarudzbaUredi>(response.Content);
            model.NarudzbaDetalji = detaljiResponse.Content;

            return View(model);
        }

        public async Task<IActionResult> OdobriNarudzbu(int id)
        {
            await _restoranApi.UpdateStatusAsync(id, 1);
            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> OdbijNarudzbu(int id)
        {
            await _restoranApi.UpdateStatusAsync(id, 2);
            return Redirect(nameof(Index));
        }
    }
}
