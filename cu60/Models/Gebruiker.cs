namespace ContosoUniversity.Models
{
    public class Gebruiker
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string BSN { get; set; }
        public int VakantieDagen { get; set; }
        public Positie Positie { get; set; }
        public string opmerkingen { get; set; }
        public DateOnly datumInDienst { get; set; }
    }
}
