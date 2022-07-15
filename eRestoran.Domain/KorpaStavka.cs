using System.ComponentModel.DataAnnotations;

namespace eRestoran.Domain
{
    public class KorpaStavka
    {
        [Key]
        public int ID { get; set; }
        public int JeloID { get; set; }
        public Jelo Jelo { get; set; }
        public int Kolicina { get; set; }
        public string KorpaID { get; set; }
    }
}