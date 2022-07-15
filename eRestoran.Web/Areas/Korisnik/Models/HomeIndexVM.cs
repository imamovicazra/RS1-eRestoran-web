using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Korisnik.Models
{
    public class HomeIndexVM
    {
        public class Jelo
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public string Slika { get; set; }
            public string Opis { get; set; }
            public double Cijena { get; set; }
        }

        public IEnumerable<Jelo> Jela { get; set; }
    }
}
