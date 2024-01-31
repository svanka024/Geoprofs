using Microsoft.AspNetCore.Identity;

namespace GeoProfsNew.Models
{
    public class Position : IdentityRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
