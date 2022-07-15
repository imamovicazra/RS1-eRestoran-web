using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Contracts.Requests
{
    public class NarudzbaUpdateRequest
    {
        public List<NarudzbaDetaljiUpsertRequest> NarudzbaDetalji { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public int StatusDostaveID { get; set; }
        public string NazivPlacanja { get; set; }
        public string BrojKartice { get; set; }
        public string CVV { get; set; }
    }
}
