namespace GeoProfsNew.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public User ManagerId { get; set; }
        public Department Department { get; set; }
    }
}
