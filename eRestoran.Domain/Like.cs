using System;

namespace eRestoran.Domain
{
    public class Like
    {
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int JeloID { get; set; }
        public Jelo Jelo { get; set; }
        public DateTime Datum { get; set; }
    }
}
