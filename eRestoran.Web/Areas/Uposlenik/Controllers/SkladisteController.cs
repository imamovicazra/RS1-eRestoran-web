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
    public class SkladisteController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;

        public SkladisteController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            var filter = new NamirnicaSearchRequest()
            {
                Naziv = search
            };
            var paginationQuery = new PaginationQuery(page, 10);

            var response = await _restoranApi.GetNamirnicaAsync(filter, paginationQuery);
            var model = new NamirnicaPrikaz()
            {
                Content = response.Content,
                Search = search
            };
            return View(model);
        }

        public async Task<IActionResult> NamirnicaUpsert(int id = 0)
        {
           
                var kategorijeResponse = await _restoranApi.GetKategorijaAsync();

                var model = new NamirnicaUpsert();

                if (id != 0)
                {
                    var response = await _restoranApi.GetNamirnicaByIdAsync(id);
                    if (response.IsSuccessStatusCode)
                    {
                        model = _mapper.Map<NamirnicaUpsert>(response.Content);
                    }
                }
                return View(model);
           
        }

        public async Task<IActionResult> NamirnicaSnimi(NamirnicaUpsert model)
        {
            //if (ModelState.IsValid)
            //{
                var request = _mapper.Map<NamirnicaUpsertRequest>(model);

                if (model.ID != 0)
                {
                    await _restoranApi.UpdateNamirnicaAsync(model.ID, request);
                }
                else
                {
                    await _restoranApi.CreateNamirnicaAsync(request);
                }

                return Redirect(nameof(Index));
            //}
            //return View("NamirnicaUpsert");
        }

        public async Task<IActionResult> NamirnicaUkloni(int id)
        {
            await _restoranApi.DeleteNamirnicaAsync(id);
            return Redirect(nameof(Index));
        }
    }
}
