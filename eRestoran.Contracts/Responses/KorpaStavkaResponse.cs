namespace eRestoran.Contracts.Responses
{
    public class KorpaStavkaResponse
    {
        public int ID { get; set; }
        public int JeloID { get; set; }
        public JeloResponse Jelo { get; set; }
        public int Kolicina { get; set; }
        public string KorpaID { get; set; }
       
    }
}
