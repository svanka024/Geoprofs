using GeoProfs.Data;
using GeoProfs.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeoProfs.Pages.Departments;

public class IndexModel : PageModel
{
    private readonly SchoolContext _context;

    public IndexModel(SchoolContext context)
    {
        _context = context;
    }

    public IList<Department> Department { get;set; }

    public async Task OnGetAsync()
    {
        Department = await _context.Departments
            .Include(d => d.Administrator).ToListAsync();
    }
}
