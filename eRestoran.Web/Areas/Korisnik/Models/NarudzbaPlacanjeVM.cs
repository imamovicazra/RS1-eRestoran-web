using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Korisnik.Models
{
    public class NarudzbaPlacanjeVM
    {
        public int NarudzbaID { get; set; }
        public string NazivPlacanja { get; set; }

        [CreditCard(ErrorMessage ="Broj kreditne kartice nije ispravan")]
        [Required(ErrorMessage = "Obavezan unos")]
        public string BrojKartice { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [MaxLength(4, ErrorMessage = "CVV mora imati 3 ili 4 karaktera")]
        [MinLength(3, ErrorMessage = "CVV mora imati 3 ili 4 karaktera")]
        public string CVV { get; set; }
    }
}
