using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Areas.Administrator.Models;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorization(Administrator: true, Uposlenik: false, Korisnik: false)]
    public class AdministratorController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;

        public AdministratorController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> PromjenaPodataka()
        {
            var response = await _restoranApi.Me();
            var gradResponse = await _restoranApi.GetGradAsync();

            AdminDetaljiIzmjena model = _mapper.Map<AdminDetaljiIzmjena>(response.Content);
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

        public IActionResult PromjenaSifre(PromjenaSifre model = null)
        {
            return View(model);
        }

        public async Task<IActionResult> SnimiSifru(PromjenaSifre model)
        {
            var request = new ChangePasswordRequest()
            {
                OldPassword = model.StaraSifra,
                NewPassword = model.NovaSifra
            };
            var response = await _restoranApi.ChangePassword(request);

            if(response.IsSuccessStatusCode)
            {
                return Redirect("/Administrator/Ponuda/Index");
            }

            return Redirect(nameof(PromjenaSifre));
        }

        public async Task<IActionResult> SnimiPodatke(AdminDetaljiIzmjena model)
        {
            var request = _mapper.Map<KorisnikUpdateInfoRequest>(model);
            var response = await _restoranApi.LicneInformacije(request);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Administrator/Ponuda/Index");
            }

            return Redirect(nameof(PromjenaPodataka));
        }
    }
}
