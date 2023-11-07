using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.LeaveRequests
{
    public class IndexModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public IndexModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IList<LeaveRequest> LeaveRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.LeaveRequests != null)
            {
                LeaveRequest = await _context.LeaveRequests.Include(lr => lr.Status).ToListAsync();
            }
        }
    }
}
