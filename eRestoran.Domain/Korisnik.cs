using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace eRestoran.Domain
{
    public class Korisnik : IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? GradID { get; set; }
        public Grad Grad { get; set; }
        public virtual IList<KorisnikUloga> KorisnikUloge { get; set; }
    }
}