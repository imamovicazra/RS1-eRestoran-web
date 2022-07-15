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
    public class JeloController : Controller
    {
        private readonly IRestoranApi _restoranApi;
        public JeloController(IRestoranApi restoranApi)
        {
            _restoranApi = restoranApi;
        }
       
        public async Task<IActionResult> Lista(string category=null, int page = 1, string search=null)
        {
            var j = _restoranApi.Jela();
            var response = j.Result.Content;
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
            
            var filter = new JeloSearchRequest()
            {
                Kategorija = category, Naziv=search
            };

            var paginationQuery = new PaginationQuery(page, 9);
            var x = await _restoranApi.GetJeloAsync(filter, paginationQuery);
            JeloListaVM model = new JeloListaVM
            {
                Content=x.Content,
                TrenutnaKategorija = string.IsNullOrEmpty(category) ? "Sva jela" : category,
                Search = search,
                kateg=category
            };
            foreach (var jelo in model.Content.Data.ToList())
            {
                foreach (var jelo1 in LajkanaJela)
                {
                    if (jelo.ID == jelo1.ID)
                        jelo.isLiked = true;
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Like(int JeloID)
        {
            await _restoranApi.Like(JeloID);
            return RedirectToAction("Lista");
        }
        [HttpPost]
        public async Task<IActionResult> Dislike(int JeloID)
        {
            await _restoranApi.Dislike(JeloID);
            return RedirectToAction("Lista");
        }

    }
}

