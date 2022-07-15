using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestoran.Domain
{
    public class Narudzba
    {
        public int ID { get; set; }
        public int KorisnikID { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int? UposlenikID { get; set; }
        [ForeignKey("UposlenikID")]
        public virtual Korisnik Uposlenik { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public string Adresa { get; set; }
        public DateTime? DatumNarudzbe { get; set; }

        [MinLength(9,ErrorMessage ="Neispravan broj telefona")]
        [MaxLength(18, ErrorMessage = "Neispravan broj telefona")]

        [Required(ErrorMessage = "Obavezan unos")]
        public string Telefon { get; set; }
        public int StatusDostaveID { get; set; }
        public StatusDostave StatusDostave { get; set; }
        public int? NacinPlacanjaID { get; set; }
        public NacinPlacanja NacinPlacanja { get; set; }
    }
}
