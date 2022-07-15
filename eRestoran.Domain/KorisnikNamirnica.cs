namespace eRestoran.Domain
{
    public class KorisnikNamirnica
    {
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int NamirnicaID { get; set; }
        public Namirnica Namirnica { get; set; }
    }
}
