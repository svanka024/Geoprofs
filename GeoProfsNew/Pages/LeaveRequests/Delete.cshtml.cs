using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfsNew.Data;
using GeoProfsNew.Models;

namespace GeoProfsNew.Pages.LeaveRequests
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }
            var leaverequest = await _context.LeaveRequests.FindAsync(id);

            if (leaverequest != null)
            {
                LeaveRequest = leaverequest;
                _context.LeaveRequests.Remove(LeaveRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
