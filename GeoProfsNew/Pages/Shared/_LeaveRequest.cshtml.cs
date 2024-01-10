using GeoProfsNew.Data;
using GeoProfsNew.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeoProfs.Pages.Shared
{
    public class _LeaveRequestModel : PageModel {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public _LeaveRequestModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<LeaveRequest> LeaveRequest { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Manager")) {
                if (_context.LeaveRequests != null) {
                    LeaveRequest = await _context.LeaveRequests
                        .Include(lr => lr.Reason)
                        .Include(lr => lr.Status)
                        .Include(lr => lr.User)
                        .ToListAsync();
                }
            }
            else if (User.IsInRole("Member")) {
                LeaveRequest = await _context.LeaveRequests
                        .Include(lr => lr.Reason)
                        .Include(lr => lr.Status)
                        .Include(lr => lr.User)
                        .Where(lr => lr.User == user)
                        .ToListAsync();
            }
        }
    }
}
