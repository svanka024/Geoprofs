using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeoProfsNew.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
    }


    public class ApplicationDbContext : DbContext
    {
        
    }
    public class saldi
    {
        public class vakantiesaldi
        {
            public int Id { get; set; }
            public decimal saldi { get; set; }
        }
    }
}

