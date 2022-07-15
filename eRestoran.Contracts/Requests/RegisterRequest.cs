using System.ComponentModel.DataAnnotations;

namespace eRestoran.Contracts.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage ="Obavezan unos")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Obavezan unos")]
        public string Username { get; set; }
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
           ErrorMessage = "Email adresa nije u ispravnom formatu")]
        [Required(ErrorMessage = "Obavezan unos")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obavezan unos")]
        public string Password { get; set; }
    }
}
