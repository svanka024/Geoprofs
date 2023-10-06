namespace ContosoUniversity.Models
{
    public class Gebruiker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int verlofSaldi { get; set; }
        public Rechten rechten { get; set; }
    }
}
