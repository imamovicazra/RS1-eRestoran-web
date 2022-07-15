namespace eRestoran.Contracts.Responses
{
    public class NamirnicaResponse
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public double CijenaPoKomadu { get; set; }
        public string JedinicaMjere { get; set; }
    }
}
