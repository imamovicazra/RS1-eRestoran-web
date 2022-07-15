namespace eRestoran.Contracts.Requests
{
    public class JeloUpsertRequest
    {
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Slika { get; set; }
        public int KategorijaID { get; set; }
        public string Opis { get; set; }
    }
}
