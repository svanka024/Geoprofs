using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.LeaveRequests
{
    public class EditModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public EditModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LeaveRequest LeaveRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaverequest =  await _context.LeaveRequests.FirstOrDefaultAsync(m => m.Id == id);
            if (leaverequest == null)
            {
                return NotFound();
            }
            LeaveRequest = leaverequest;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LeaveRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestExists(LeaveRequest.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LeaveRequestExists(int id)
        {
          return _context.LeaveRequests.Any(e => e.Id == id);
        }
    }
}
