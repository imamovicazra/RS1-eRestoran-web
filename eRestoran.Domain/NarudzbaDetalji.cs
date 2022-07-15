using System.ComponentModel.DataAnnotations;

namespace eRestoran.Domain
{
    public class NarudzbaDetalji
    {
        [Key]
        public int ID { get; set; }
        public int NarudzbaID { get; set; }
        public Narudzba Narudzba { get; set; }
        public int JeloID { get; set; }
        public Jelo Jelo { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
    }
}
