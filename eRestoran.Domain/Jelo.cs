namespace eRestoran.Domain
{
    public class Jelo
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Slika { get; set; }
        public int KategorijaID { get; set; }
        public bool Favorit { get; set; }
        public Kategorija Kategorija { get; set; }
        public string Opis { get; set; }
    }
}