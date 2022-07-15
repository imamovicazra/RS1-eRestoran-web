namespace eRestoran.Contracts.Responses
{
    public class JeloResponse
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Slika { get; set; }
        public int KategorijaID { get; set; }
        public KategorijaResponse Kategorija { get; set; }
        public string Opis { get; set; }
        public bool Favorit { get; set; }
        public bool isLiked { get; set; }
    }
}
