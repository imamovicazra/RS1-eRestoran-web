namespace eRestoran.Contracts.Requests
{
    public class KorisnikUpdateInfoRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public int? GradID { get; set; }
    }
}
