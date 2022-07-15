using Microsoft.AspNetCore.Identity;

namespace eRestoran.Domain
{
    public class KorisnikClaim : IdentityUserClaim<int>
    {
        public virtual Korisnik Korisnik { get; set; }
    }
}
