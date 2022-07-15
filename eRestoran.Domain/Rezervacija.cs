using System;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Domain
{
    public class Rezervacija
    {
        public int ID { get; set; }
        public DateTime DatumVrijemeEvidencije { get; set; }

        [DataType(DataType.Date,ErrorMessage ="Obavezan unos")]
        [Required(ErrorMessage = "Obavezan unos")]
        public DateTime? DatumVrijemeRezervacije { get; set; }
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        public string Telefon { get; set; }
        public int? UposlenikID { get; set; }
        public Korisnik Uposlenik { get; set; }

        [Range(1,100, ErrorMessage ="Broj mjesta mora biti veći od 0")]
        [Required (ErrorMessage ="Obavezan unos")]
        public int? BrojMjesta { get; set; }
    }
}
