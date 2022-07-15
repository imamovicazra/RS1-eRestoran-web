using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Contracts.Requests;
using eRestoran.Domain;
using eRestoran.Sdk;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Areas.Korisnik.Controllers
{
    [Area("Korisnik")]
    [Authorization(Administrator: false, Uposlenik: false, Korisnik: true)]
    public class RezervacijaController : Controller
    {
        IRestoranApi _restoranApi;
        public RezervacijaController(IRestoranApi restoranApi)
        {
            _restoranApi = restoranApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rezervisi()
        {
            return View();
        }
        public IActionResult UspjesnaRezervacija()
        {
            ViewBag.CheckoutCompleteMessage = "Uspješna rezervacija! Vaš sto se čuva do pola sata nakon isteka rezervacije. :)";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RezervisiAsync(Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                RezervacijaInsertRequest insertRequest = new RezervacijaInsertRequest
                {
                    Telefon = rezervacija.Telefon,
                    DatumVrijemeRezervacije = (DateTime)rezervacija.DatumVrijemeRezervacije,
                    BrojMjesta = (int)rezervacija.BrojMjesta
                };

                await _restoranApi.CreateRezervacijaAsync(insertRequest);
                return RedirectToAction("UspjesnaRezervacija");
            }
            return View(rezervacija);
        }
    }
}
