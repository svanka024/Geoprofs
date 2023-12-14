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

namespace GeoProfsNew.Pages
{
    public class IndexModel : PageModel
    {
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

        public LeaveRequest LeaveRequest { get; set; }
        public List<SelectListItem> ReasonTypes { get; set; }

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