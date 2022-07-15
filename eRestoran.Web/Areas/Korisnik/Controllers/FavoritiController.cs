using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class FavoritiController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        public FavoritiController(IRestoranApi restoranApi)
        {
            _restoranApi = restoranApi;
        }
        public IActionResult Index()
        {
            var x = _restoranApi.Jela();
            var response = x.Result.Content;
            List<Jelo> LajkanaJela = new List<Jelo>();

     
            foreach (var s in response)
            {
                Jelo jelo = new Jelo
                {
                    ID = s.ID,
                    Cijena = s.Cijena,
                    Favorit = s.Favorit,
                    Kategorija = new Kategorija { ID = s.Kategorija.ID, Naziv = s.Kategorija.Naziv, Opis = s.Kategorija.Opis },
                    Naziv = s.Naziv,
                    KategorijaID = s.KategorijaID,
                    Opis = s.Opis,
                    Slika = s.Slika
                };
                LajkanaJela.Add(jelo);
            }
            FavoritiIndexVM model = new FavoritiIndexVM { Jela = LajkanaJela };
            return View(model);
        }
        public async Task<IActionResult> Dislike(int JeloID)
        {
            var x=await _restoranApi.Dislike(JeloID);
            return RedirectToAction("Index");
        }
    }
}
