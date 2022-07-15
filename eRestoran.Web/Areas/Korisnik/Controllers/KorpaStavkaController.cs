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
using Microsoft.AspNetCore.Mvc;

namespace eRestoran.Web.Areas.Korisnik.Controllers
{
    [Area("Korisnik")]
    [Authorization(Administrator: false, Uposlenik: false, Korisnik: true)]
    public class KorpaStavkaController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        private readonly IMapper _mapper;
        public KorpaHelper _korpaHelper;
        public KorpaStavkaController(IRestoranApi restoranApi, IMapper mapper, KorpaHelper korpaHelper)
        {
            _restoranApi = restoranApi;
            _mapper = mapper;
            _korpaHelper = korpaHelper;
        }
      

        public async Task<IActionResult> IndexAsync()
        {
            var stavke = _korpaHelper.GetStavkeAsync();
            _korpaHelper.stavke = await stavke;
            var model = new KorpaStavkaVM
            {
                KorpaStavke = await _korpaHelper.GetStavkeAsync(),
                KorpaUkupno = await _korpaHelper.UkupnoAsync()
            };
            return View(model);
        }          
            
    

    public async Task<IActionResult> DodajUKorpuAsync(int JeloID)
        {
            var x = await _restoranApi.GetJeloAsync();
            Jelo odabranoJelo = x.Content.Data.Select(jelo => new Jelo
            {
                ID = jelo.ID,
                Naziv = jelo.Naziv,
                Cijena = jelo.Cijena,
                Opis = jelo.Opis,
                Slika = jelo.Slika,
                Kategorija = new Kategorija
                {
                    ID = jelo.Kategorija.ID,
                    Naziv = jelo.Kategorija.Naziv,
                    Opis = jelo.Kategorija.Opis
                },
                KategorijaID = jelo.KategorijaID,
                Favorit = jelo.Favorit
            }).Where(j => j.ID == JeloID).FirstOrDefault();
            if(odabranoJelo!=null)
            {
                await _korpaHelper.DodajUKorpuAsync(odabranoJelo, 1);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UkloniIzKorpeAsync(int JeloID)
        {
            var x = await _restoranApi.GetJeloAsync();
            Jelo odabranoJelo = x.Content.Data
                .Select(j => new Jelo
                {
                    ID = j.ID,
                    Kategorija = new Kategorija { ID = j.Kategorija.ID, Naziv = j.Kategorija.Naziv, Opis = j.Kategorija.Opis },
                    KategorijaID = j.KategorijaID,
                    Naziv = j.Naziv,
                    Cijena = j.Cijena,
                    Opis = j.Opis,
                    Favorit = j.Favorit,
                    Slika = j.Slika
                })
                .Where(j => j.ID == JeloID).SingleOrDefault();
            if (odabranoJelo != null)
            {
                await _korpaHelper.UkloniIzKorpeAsync(odabranoJelo);
            }
            return RedirectToAction("Index");
        }
    }
}
