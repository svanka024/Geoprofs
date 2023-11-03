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
      public List<Status> StatusItems { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaverequest = await _context.LeaveRequests.Include(lr => lr.Status).FirstOrDefaultAsync(m => m.Id == id);
            if (leaverequest == null)
            {
                return NotFound();
            }
            else
            {
                LeaveRequest = leaverequest;
            }

            StatusItems = await _context.Statuses.ToListAsync();

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

            var existingLeaveRequest = await _context.LeaveRequests
                .AsNoTracking() // Prevents tracking the entity to avoid conflict issues
                .FirstOrDefaultAsync(m => m.Id == LeaveRequest.Id);

            if (existingLeaveRequest == null)
            {
                return NotFound();
            }

            // Apply model binding restrictions
            _context.Entry(existingLeaveRequest).CurrentValues.SetValues(LeaveRequest);
            _context.Entry(existingLeaveRequest).Property("Status").IsModified = true; // Only allow updating Status

            //_context.Attach(LeaveRequest).State = EntityState.Modified;

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
