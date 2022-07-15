using Microsoft.AspNetCore.Identity;

namespace eRestoran.Domain
{
    public class KorisnikLogin : IdentityUserLogin<int>
    {
        public virtual Korisnik Korisnik { get; set; }
    }
}
