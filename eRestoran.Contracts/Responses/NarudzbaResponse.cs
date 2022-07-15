using System;
using System.Collections.Generic;

namespace eRestoran.Contracts.Responses
{
    public class NarudzbaResponse
    {
        public int ID { get; set; }
        public int KorisnikID { get; set; }
        public KorisnikResponse Korisnik { get; set; }
        public int UposlenikID { get; set; }
        public KorisnikResponse Uposlenik { get; set; }
        public string Adresa { get; set; }
        public DateTime? DatumNarudzbe { get; set; }
        public string Telefon { get; set; }
        public int StatusDostaveID { get; set; }
        public StatusDostaveResponse StatusDostave { get; set; }
    }
}
