namespace ContosoUniversity.Models
{
    public class Verlof
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public Status status { get; set; }
        public VerlofReden reden { get; set; }
        public Gebruiker gebruiker { get; set; }
        public Gebruiker medewerker { get; set; }
    }
}
