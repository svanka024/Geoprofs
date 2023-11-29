using GeoProfs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeoProfs.Pages.Shared
{
    public class _LeaveRequestsModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public _LeaveRequestsModel(GeoProfs.Data.GeoProfsContext context)
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
