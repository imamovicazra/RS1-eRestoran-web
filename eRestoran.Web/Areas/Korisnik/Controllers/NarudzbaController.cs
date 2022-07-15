using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Domain;
using eRestoran.Sdk;
using eRestoran.Web.Areas.Korisnik.Models;
using eRestoran.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Areas.Korisnik.Controllers
{
    [Area("Korisnik")]
    [Authorization(Administrator: false, Uposlenik: false, Korisnik: true)]
    public class NarudzbaController : Controller
    {
        
        private readonly IRestoranApi _restoranApi;
      
        private KorpaHelper _korpaHelper;
        public NarudzbaController(IRestoranApi restoranApi,KorpaHelper korpaHelper)
        {
            _restoranApi = restoranApi;         
            _korpaHelper = korpaHelper;
        }
        
        public IActionResult Naruci()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NaruciAsync(Narudzba narudzba)
        {
             var stavke = _korpaHelper.GetStavkeAsync();
            _korpaHelper.stavke =await stavke;
            if (_korpaHelper.stavke.Count == 0)
            {
                ModelState.AddModelError("", "Korpa je prazna, dodajte jelo");
            }
            if (ModelState.IsValid)
            {
                List<NarudzbaDetaljiUpsertRequest> detalji = new List<NarudzbaDetaljiUpsertRequest>();
                foreach (var s in _korpaHelper.stavke)
                {
                    NarudzbaDetaljiUpsertRequest narudzbaDetalji = new NarudzbaDetaljiUpsertRequest
                    {
                        Kolicina = s.Kolicina,
                        JeloID = s.JeloID,
                        Cijena = s.Jelo.Cijena
                    };
                    detalji.Add(narudzbaDetalji);
                }
                NarudzbaInsertRequest upsert = new NarudzbaInsertRequest
                {
                    NarudzbaDetalji = detalji,
                    Adresa = narudzba.Adresa,
                    Telefon = narudzba.Telefon,
                    StatusDostaveID = 3,
                    DatumNarudzbe = DateTime.Now
                                      
                };

                var response = await _restoranApi.CreateNarudzbaAsync(upsert);
                 
                
                await _korpaHelper.IzbrisiStavkeAsync();
                return RedirectToAction("Placanje", new { id=response.Content.ID });
            }
            return View(narudzba);

        }
        public IActionResult UspjesnaNarudzba()
        {
            ViewBag.CheckoutCompleteMessage = "Hvala za narudžbu, očekujte poziv dostavljača u narednih 30 minuta! :)";
            return View();
        }
        public IActionResult Placanje(int id)
        {
            NarudzbaPlacanjeVM m = new NarudzbaPlacanjeVM { NarudzbaID = id };
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Placanje(NarudzbaPlacanjeVM nacinPlacanja)
        {
            NarudzbaUpdateRequest updateRequest = new NarudzbaUpdateRequest();
            if (nacinPlacanja.NazivPlacanja == "Pouzećem")
            {
                updateRequest = new NarudzbaUpdateRequest
                {
                    NazivPlacanja = nacinPlacanja.NazivPlacanja,
                };
            }
            else if (nacinPlacanja.NazivPlacanja == "Karticom")
            {
                if (ModelState.IsValid)
                {
                    updateRequest = new NarudzbaUpdateRequest
                    {
                        NazivPlacanja = nacinPlacanja.NazivPlacanja,
                        BrojKartice = nacinPlacanja.BrojKartice,
                        CVV = nacinPlacanja.CVV
                    };
                   
                }
                else
                {
                    return View(nacinPlacanja);
                }
            }

            await _restoranApi.UpdateNarudzbaAsync(nacinPlacanja.NarudzbaID, updateRequest);
            return RedirectToAction("UspjesnaNarudzba");
        }
    }
}
