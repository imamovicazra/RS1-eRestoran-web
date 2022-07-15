using System.ComponentModel.DataAnnotations;

namespace eRestoran.Domain
{
    public class NacinPlacanja
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public string BrojKartice { get; set; }
       
        public string CVV { get; set; }
    }
}
