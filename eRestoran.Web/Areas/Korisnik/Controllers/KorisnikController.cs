using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Areas.Korisnik.Models;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eRestoran.Web.Areas.Korisnik.Controllers
{
    [Area("Korisnik")]
    [Authorization(Administrator: false, Uposlenik: false, Korisnik: true)]
    public class KorisnikController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;
        public KorisnikController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> PromjenaPodataka()
        {
            var response = await _restoranApi.Me();
            var gradResponse = await _restoranApi.GetGradAsync();

            KorisnikDetaljiIzmjenaVM model = _mapper.Map<KorisnikDetaljiIzmjenaVM>(response.Content);
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
        public IActionResult PromjenaSifre(PromjenaSifreVM model = null)
        {
            return View(model);
        }
        public async Task<IActionResult> SnimiSifru(PromjenaSifreVM model)
        {
            var request = new ChangePasswordRequest()
            {
                OldPassword = model.StaraSifra,
                NewPassword = model.NovaSifra
            };
            var response = await _restoranApi.ChangePassword(request);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Korisnik/Home/Index");
            }

            return Redirect(nameof(PromjenaSifre));
        }
        public async Task<IActionResult> SnimiPodatke(KorisnikDetaljiIzmjenaVM model)
        {
            var request = _mapper.Map<KorisnikUpdateInfoRequest>(model);
            var response = await _restoranApi.LicneInformacije(request);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Korisnik/Home/Index");
            }

            return Redirect(nameof(PromjenaPodataka));
        }
    }
}
