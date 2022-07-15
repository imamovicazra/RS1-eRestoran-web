using eRestoran.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Contracts.Requests
{
   public  class NarudzbaDetaljiUpsertRequest
    {
        public int NarudzbaID { get; set; }
        public int Kolicina { get; set; }
        public int JeloID { get; set; }
        public double Cijena { get; set; }
        
    }
}
