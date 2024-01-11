using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfsNew.Models;
using GeoProfsNew.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GeoProfsNew.Data.Migrations;

namespace GeoProfsNew.Pages.LeaveRequests
{
    [Authorize(Roles = "Manager,Member")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<LeaveRequest> LeaveRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Manager"))
            {
                if (_context.LeaveRequests != null)
                {
                    LeaveRequest = await _context.LeaveRequests
                        .Include(lr => lr.Reason)
                        .Include(lr => lr.Status)
                        .Include(lr => lr.User)
                        .ToListAsync();
                }
            }
            else if(User.IsInRole("Member"))
            {
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
