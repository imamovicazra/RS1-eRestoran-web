using System;
using System.ComponentModel.DataAnnotations;

namespace eRestoran.Contracts.Requests
{
    public class RezervacijaInsertRequest
    {
        public DateTime DatumVrijemeRezervacije { get; set; }
        public int BrojMjesta { get; set; }
        public string Telefon { get; set; }
    }
}
