namespace TestProjectBackend.Models.Entities
{
    public class Faktura
    {
        public Guid Id { get; set; }
        public int Broj { get; set; }
        public DateTime Datum { get; set; }
        public string Partner { get; set; }
        public decimal IznosBezPdv { get; set; }
        public decimal PostoRabata { get; set; }
        public decimal Rabat { get; set; }
        public decimal IznosSaRabatomBezPdv { get; set; }
        public decimal Pdv { get; set; }
        public decimal Ukupno { get; set; }
        public List<StavkaFakture> StavkeFakture { get; set; }

    }
}
