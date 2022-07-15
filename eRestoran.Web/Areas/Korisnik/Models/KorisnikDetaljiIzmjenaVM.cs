using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Korisnik.Models
{
    public class KorisnikDetaljiIzmjenaVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        [DisplayName("Grad")]
        public int? GradID { get; set; }
        public IList<SelectListItem> Gradovi { get; set; }
    }
}
