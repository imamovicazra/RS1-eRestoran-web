using Microsoft.AspNetCore.Identity;

namespace eRestoran.Domain
{
    public class UlogaClaim : IdentityRoleClaim<int>
    {
        public virtual Uloga Uloga { get; set; }
    }
}
