using eRestoran.Contracts.Responses;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace eRestoran.Web.Areas.Uposlenik.Models
{
    public class NarudzbaUredi
    {
        public int ID { get; set; }
        public int KorisnikID { get; set; }
        public KorisnikResponse Korisnik { get; set; }

        [DisplayName("Korisnik")]
        public string KorisnikImePrezime => $"{Korisnik.Ime} {Korisnik.Prezime}";
        public int UposlenikID { get; set; }
        public KorisnikResponse Uposlenik { get; set; }

        [DisplayName("Uposlenik")]
        public string UposlenikImePrezime => $"{Uposlenik?.Ime} {Uposlenik?.Prezime}";

        public string Adresa { get; set; }
        public DateTime? DatumNarudzbe { get; set; }
        public string Telefon { get; set; }
        public int StatusDostaveID { get; set; }
        public List<NarudzbaDetaljiResponse> NarudzbaDetalji { get; set; }
    }
}
