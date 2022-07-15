namespace eRestoran.Contracts.Responses
{
    public class NarudzbaDetaljiResponse
    {
        public int ID { get; set; }
        public int Kolicina { get; set; }
        public int JeloID { get; set; }
        public JeloResponse Jelo { get; set; }
        public int NarudzbaID { get; set; }
        public double Cijena { get; set; }
    }
}
