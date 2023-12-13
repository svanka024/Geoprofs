using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoProfsNew.Models;
using GeoProfsNew.Data;
using Microsoft.AspNetCore.Identity;

namespace GeoProfsNew.Pages.LeaveRequests
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ReasonTypes = _context.Reasons
                  .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                  .ToList();

            LeaveRequest = new LeaveRequest
            {
                Status = _context.Statuses.FirstOrDefault()
            };

            return Page();
        }

        [BindProperty]
        public LeaveRequest LeaveRequest { get; set; }
        public List<SelectListItem> ReasonTypes { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (int.TryParse(Request.Form["LeaveRequest.Reason"], out int selectedReasonId))
            {
                LeaveRequest.Reason = _context.Reasons.Find(selectedReasonId);
            }
            else
            {
                ModelState.AddModelError("LeaveRequest.Reason", "Please select a reason.");
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            LeaveRequest.Status = _context.Statuses.FirstOrDefault();
            LeaveRequest.User = currentUser;

            _context.LeaveRequests.Add(LeaveRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
