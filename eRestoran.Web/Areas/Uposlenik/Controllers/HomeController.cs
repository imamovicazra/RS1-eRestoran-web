using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Sdk;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Areas.Uposlenik.Controllers
{
    [Area("Uposlenik")]
    [Authorization(Administrator: false, Uposlenik: true, Korisnik: false)]
    public class HomeController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;

        public HomeController(IRestoranApi restoranApi, IMapper mapper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var response = await _restoranApi.Me();
            string korisnik = response.Content.Ime + " " + response.Content.Prezime;
            ViewBag.Poruka = "Dobro došao " + korisnik + "!";
            return View();
        }
    }
}
