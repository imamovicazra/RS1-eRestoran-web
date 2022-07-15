using Microsoft.AspNetCore.Identity;

namespace eRestoran.Domain
{
    public class KorisnikUloga : IdentityUserRole<int>
    {
        public virtual Korisnik Korisnik { get; set; }
        public virtual Uloga Uloga { get; set; }
    }
}