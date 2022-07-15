using System.ComponentModel.DataAnnotations;

namespace eRestoran.Contracts.Requests
{
    public class LoginRequest
    {
        [EmailAddress]

        //[Required(ErrorMessage = "Obavezan unos")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Obavezan unos")]
        public string Password { get; set; }
    }
}
