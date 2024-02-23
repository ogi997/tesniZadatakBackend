namespace TestProjectBackend.Models.Entities
{
    public class StavkaFakture
    {
        public Guid Id { get; set; }
        public Guid FakturaId { get; set; }
        public int Rbr { get; set; }
        public string NazivArtikla { get; set; }
        public decimal Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal IznosBezPdv { get; set; }
        public decimal PostoRabata { get; set; }
        public decimal Rabat { get; set; }
        public decimal IznosSaRabatomBezPdv { get; set; }
        public decimal Pdv { get; set; }
        public decimal Ukupno { get; set; }
    }
}
