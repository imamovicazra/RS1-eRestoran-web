using Microsoft.AspNetCore.Identity;

namespace eRestoran.LocalizationService
{
    public class IdentityErrorDescriberBA : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "Lozinka mora sadržavati bar jedno veliko slovo (A - Z)."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Lozinka mora sadržavati bar jedno malo slovo (a - z)."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Lozinka mora sadržavati bar jednu cifru."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Lozinka mora sadržavati bar jedan specijalni karakter (!@,$.#+)."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format("Lozinka mora sadržavati bar 6 karaktera. ", length)
            };
        }
    }
}
