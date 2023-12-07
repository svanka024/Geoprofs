using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    
    public class saldi
    {
        public class vakantiesaldi
        {
            Console.WriteLine($"vakantiesaldi");
        }
        public class gebruiktesaldi
        {
            Console.WriteLine($"gebruiktesaldi");
        }
        public class totaalsaldi
        {
            Console.WriteLine($"totaalsaldi");
        }
    }
}

