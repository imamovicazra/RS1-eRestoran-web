namespace eRestoran.Contracts.Requests
{
    public class NamirnicaUpsertRequest
    {
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public double CijenaPoKomadu { get; set; }
        public string JedinicaMjere { get; set; }
    }
}
