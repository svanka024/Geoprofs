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
    public class DetailsModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public DetailsModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

      public LeaveRequest LeaveRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaverequest = await _context.LeaveRequests.FirstOrDefaultAsync(m => m.Id == id);
            if (leaverequest == null)
            {
                return NotFound();
            }
            else 
            {
                LeaveRequest = leaverequest;
            }
            return Page();
        }
    }
}
