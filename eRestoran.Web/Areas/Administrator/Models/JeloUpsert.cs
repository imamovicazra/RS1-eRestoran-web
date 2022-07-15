using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Web.Areas.Administrator.Models
{
    public class JeloUpsert
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Cijena mora biti veća od 0.")]
        public double Cijena { get; set; }
        public string Slika { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        [DisplayName("Kategorija")]
        public int KategorijaID { get; set; }
        public List<SelectListItem> Kategorije { get; set; }
    }
}
