using System.Collections.Generic;

namespace eRestoran.Contracts.Responses
{
    public class KorisnikResponse
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int? GradID { get; set; }
        public ICollection<UlogaResponse> Uloge { get; set; }
    }
}
