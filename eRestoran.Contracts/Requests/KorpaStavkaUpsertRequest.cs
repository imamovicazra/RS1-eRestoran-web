using eRestoran.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Contracts.Requests
{
    public class KorpaStavkaUpsertRequest
    {
        public int JeloID { get; set; }
        public string KorpaID { get; set; }
        public int Kolicina { get; set; }
    }
}
