using GeoProfs.Data;
using GeoProfs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeoProfs.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly GeoProfsContext _context;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public IndexModel(GeoProfsContext context)
        {
            _context = context;
        }
        public IList<LeaveRequest> LeaveRequest { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.LeaveRequests != null) {
                LeaveRequest = await _context.LeaveRequests.Include(lr => lr.Reason).Include(lr => lr.Status).ToListAsync();
            }
        }
    }
}