namespace GeoProfs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BSN { get; set; }
        public int VacationDays { get; set; }
        public Position Position { get; set; }
        public Department Department { get; set; }
        public DateOnly DateService { get; set; }
        public string Comments { get; set; }
        public Account Account { get; set; }
    }
}
