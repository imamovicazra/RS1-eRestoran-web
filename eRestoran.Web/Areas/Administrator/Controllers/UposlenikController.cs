using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Areas.Administrator.Models;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorization(Administrator: true, Uposlenik: false, Korisnik: false)]
    public class UposlenikController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;

        public UposlenikController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            var filter = new KorisnikSearchRequest()
            {
                Ime = search,
                Prezime = search,
                Email = search,
                Uloge = new List<string> { "Uposlenik" }
            };
            var paginationQuery = new PaginationQuery(page, 10);

            var response = await _restoranApi.GetKorisnikAsync(filter, paginationQuery);

            var model = new UposlenikPrikaz();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                model = new UposlenikPrikaz()
                {
                    Content = response.Content,
                    Search = search
                };
            }
            return View(model);
        }

        public async Task<IActionResult> UposlenikDetalji(int id = 0)
        {
            var ulogeResponse = await _restoranApi.GetUlogaAsync();
            var gradResponse = await _restoranApi.GetGradAsync();

            var model = new UposlenikDetalji();

            var response = await _restoranApi.GetKorisnikByIdAsync(id);
            if (response.IsSuccessStatusCode)
            {
                model = _mapper.Map<UposlenikDetalji>(response.Content);
                model.TrenutneUloge = response.Content.Uloge.Select(i => i.Id).ToList();

                foreach (var item in ulogeResponse.Content.Data)
                {
                    var IsSelected = model.TrenutneUloge.Contains(item.Id);
                    model.SveUloge.Add
                    (
                         new KorisnikUlogaCheckListItem
                         {
                             Id = item.Id,
                             Name = item.Name,
                             IsSelected = IsSelected
                         }
                    );
                }
            }

            model.Gradovi = gradResponse.Content.Data.Select
                (
                    i => new SelectListItem()
                    {
                        Text = i.Naziv,
                        Value = i.ID.ToString()
                    }
                ).ToList();



            return View(model);
        }

        public async Task<IActionResult> UposlenikSnimi(UposlenikDetalji model)
        {
            List<string> noveUloge = model.SveUloge.Where(i => i.IsSelected)
                .Where(i => !model.TrenutneUloge.Contains(i.Id))
                .Select(i => i.Name)
                .ToList();

            List<string> obrisaneUloge = model.SveUloge.Where(i => !i.IsSelected)
                .Where(i => model.TrenutneUloge.Contains(i.Id))
                .Select(i => i.Name)
                .ToList();

            var request = new KorisnikUpdateRequest()
            {
                NoveUloge = noveUloge,
                ObrisaneUloge = obrisaneUloge
            };

            await _restoranApi.UpdateKorisnikAsync(model.Id, request);
            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> UposlenikUkloni(int id)
        {
            await _restoranApi.DeleteKorisnikAsync(id);
            return Redirect(nameof(Index));
        }
    }
}
