using System.ComponentModel.DataAnnotations;

namespace GeoProfs.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public User User { get; set; }
        public User Manager { get; set; }
        public Reason Reason { get; set; }
        public Status Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
    }
}
