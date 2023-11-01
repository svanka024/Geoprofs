namespace GeoProfs.Models
{
    public class LeaveRequest
    {
        public string Id { get; set; }
        public User User { get; set; }
        public User Manager { get; set; }
        public Reason Reason { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
