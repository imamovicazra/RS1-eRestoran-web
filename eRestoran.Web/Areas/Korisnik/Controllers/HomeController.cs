using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Sdk;
using eRestoran.Web.Areas.Korisnik.Models;
using eRestoran.Web.Areas.Uposlenik.Controllers;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Areas.Korisnik.Controllers
{
    [Area("Korisnik")]
    [Authorization(Administrator: false, Uposlenik: false, Korisnik: true)]
    public class HomeController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        public HomeController(IRestoranApi restoranApi)
        {
            _restoranApi = restoranApi;
        }
        public async Task<IActionResult> Index()
        {
            var x = await _restoranApi.GetJeloAsync();
            HomeIndexVM model = new HomeIndexVM
            {
                Jela = x.Content.Data.Where(x=>x.Favorit==true).Select(jelo => new HomeIndexVM.Jelo
                {
                    ID=jelo.ID,
                    Naziv = jelo.Naziv,
                    Slika = jelo.Slika,
                    Opis = jelo.Opis,
                    Cijena = jelo.Cijena
                }).ToList(),
                

            };
            return View(model);
        }
    }
}
