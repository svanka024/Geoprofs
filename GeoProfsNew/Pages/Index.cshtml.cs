using GeoProfsNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoProfsNew.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using GeoProfsNew.Data.Migrations;
using System.Data;
using Microsoft.AspNetCore.Authorization;


namespace GeoProfsNew.Pages
{
    [Authorize(Roles = "Manager,Member")]
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public void OnGet()
        {

        }

        //public LeaveRequest LeaveRequest { get; set; }
        public IList<LeaveRequest> LeaveRequest { get; set; } = default!;
        public List<SelectListItem> ReasonTypes { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var LeaveRequest = new LeaveRequest
            {
                Reason = _context.Reasons.FirstOrDefault(),
                Status = _context.Statuses.FirstOrDefault(),
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now,
                User = currentUser, // Assign the currently logged-in user to LeaveRequest.User
            };

            _context.LeaveRequests.Add(LeaveRequest);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Reported sick";
            return RedirectToPage("./Index");
        }
    }
}