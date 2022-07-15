using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Web.Areas.Uposlenik.Models
{
    public class NamirnicaUpsert
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Obavezan unos")]
        public string Naziv { get; set; }

        
        [Range(0.1,999.999, ErrorMessage ="Obavezan unos" )]
        [Required(ErrorMessage = "Obavezan unos")]
        public int Kolicina { get; set; }

        [Range(0.1, 999.999, ErrorMessage = "Obavezan unos")]
        [Required(ErrorMessage = "Obavezan unos")]
        [DisplayName("Cijena po komadu")]
        public double CijenaPoKomadu { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        [DisplayName("Jedinica mjere")]
        public string JedinicaMjere { get; set; }
    }
}
