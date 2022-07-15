using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.EmailService;
using eRestoran.Sdk;
using eRestoran.Web.Areas.Administrator.Models;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorization(Administrator: true, Uposlenik: false, Korisnik: false)]
    public class PonudaController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;

        public PonudaController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            var filter = new JeloSearchRequest()
            {
                Naziv = search
            };
            var paginationQuery = new PaginationQuery(page, 10);

            var response = await _restoranApi.GetJeloAsync(filter, paginationQuery);
            var model = new JelaPrikaz()
            {
                Content = response.Content,
                Search = search
            };
            return View(model);
        }

        public async Task<IActionResult> JeloUpsert(int id = 0)
        {
            var kategorijeResponse = await _restoranApi.GetKategorijaAsync();
            
            var model = new JeloUpsert();

            if(id != 0)
            {
                var response = await _restoranApi.GetJeloByIdAsync(id);
                if(response.IsSuccessStatusCode)
                {
                    model = _mapper.Map<JeloUpsert>(response.Content);
                }
            }

            model.Kategorije = kategorijeResponse.Content.Data.Select
                (
                    i => new SelectListItem()
                    {
                        Text = i.Naziv,
                        Value = i.ID.ToString()
                    }
                ).ToList();

            return View(model);
        }

        public async Task<IActionResult> JeloSnimi(JeloUpsert model, IFormFile slika)
        {
            if (ModelState.IsValid)
            {
                if (slika != null && slika.Length > 0)
                {
                    model.Slika = await ImageHelper.Upload(slika, "jela", Path.GetFileName(slika.FileName));
                }

                var request = _mapper.Map<JeloUpsertRequest>(model);

                if (model.ID != 0)
                {
                    await _restoranApi.UpdateJeloAsync(model.ID, request);
                }
                else
                {
                    await _restoranApi.CreateJeloAsync(request);
                }

                return Redirect(nameof(Index));
            }
            return View("JeloUpsert");
        }

        public async Task<IActionResult> JeloUkloni(int id)
        {
            await _restoranApi.DeleteJeloAsync(id);
            return Redirect(nameof(Index));
        }
    }
}
