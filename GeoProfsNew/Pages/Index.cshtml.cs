using GeoProfsNew.Data;
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

        public ActionResult DisplayUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = context.Users.ToList();
                return View(users);
            }
        }

    }
}

