using System.Collections.Generic;

namespace eRestoran.Contracts.Requests
{
    public class KorisnikSearchRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public List<string> Uloge { get; set; }
    }
}
