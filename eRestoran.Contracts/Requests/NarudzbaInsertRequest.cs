using eRestoran.Domain;
using System;
using System.Collections.Generic;

namespace eRestoran.Contracts.Requests
{
    public class NarudzbaInsertRequest
    {
        public List<NarudzbaDetaljiUpsertRequest> NarudzbaDetalji { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public int StatusDostaveID { get; set; }
        
    }
}
