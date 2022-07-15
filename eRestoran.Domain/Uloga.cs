using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace eRestoran.Domain
{
    public class Uloga : IdentityRole<int>
    {
        public virtual IList<KorisnikUloga> KorisnikUloge { get; set; }
        public virtual IList<UlogaClaim> UlogaClaims { get; set; }
    }
}
