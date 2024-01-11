using GeoProfsNew.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeoProfsNew.Pages
{
    public class IndexModel : PageModel
    {
        public ActionResult DisplayData()
        {
            // Read data from files and store it in a model
            var data = ReadDataFromFiles();

            // Pass data to the view
            return View(data);
        }
    }
}

