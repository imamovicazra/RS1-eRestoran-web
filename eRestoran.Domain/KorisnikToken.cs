using Microsoft.AspNetCore.Identity;

namespace eRestoran.Domain
{
    public class KorisnikToken : IdentityUserToken<int>
    {
        public virtual Korisnik Korisnik { get; set; }
    }
}
