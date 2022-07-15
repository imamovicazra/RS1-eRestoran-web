using System;

namespace eRestoran.Contracts.Responses
{
    public class RezervacijaResponse
    {
        public int ID { get; set; }
        public DateTime DatumVrijemeEvidencije { get; set; }
        public DateTime DatumVrijemeRezervacije { get; set; }
        public int KorisnikID { get; set; }
        public KorisnikResponse Korisnik { get; set; }
        public string Telefon { get; set; }
        public int? UposlenikID { get; set; }
        public KorisnikResponse Uposlenik { get; set; }
        public int BrojMjesta { get; set; }
    }
}
