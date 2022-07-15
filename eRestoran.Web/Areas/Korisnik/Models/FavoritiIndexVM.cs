using eRestoran.Contracts.Responses;
using eRestoran.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestoran.Web.Areas.Korisnik.Models
{
    public class FavoritiIndexVM
    {
        public List<Jelo> Jela { get; set; }
    }
}
