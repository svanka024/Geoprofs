namespace GeoProfsNew.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public User User { get; set; }
        public User Manager { get; set; }
        public Reason Reason { get; set; }
        public Status Status { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
    }
}
