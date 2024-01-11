using GeoProfsNew.Data;
using GeoProfsNew.Data.Migrations;
using GeoProfsNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GeoProfsNew.Pages.Manager
{
    [Authorize(Roles = "Manager")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<User> Users { get; set; } = default!;
        public IList<LeaveRequest> Sick { get; set; } = default!;
        public IList<LeaveRequest> Vacation { get; set; } = default!;
        public IList<LeaveRequest> Personal { get; set; } = default!;



        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                Users = await _context.Users
                    .ToListAsync();
            }            

            if (_context.LeaveRequests != null)
            {
                Sick = await _context.LeaveRequests
                    .Include(lr => lr.User)
                    .Where(lr => lr.Reason.Id == 1)
                    //.Where(lr => lr.Status.Id == 3)
                    .ToListAsync();
            }

            if (_context.LeaveRequests != null)
            {
                Vacation = await _context.LeaveRequests
                    .Include(lr => lr.User)
                    .Where(lr => lr.Reason.Id == 2)
                    //.Where(lr => lr.Status.Id == 3)
                    .ToListAsync();
            }

            if (_context.LeaveRequests != null)
            {
                Personal = await _context.LeaveRequests
                    .Include(lr => lr.User)
                    .Where(lr => lr.Reason.Id == 3)
                    //.Where(lr => lr.Status.Id == 3)
                    .ToListAsync();
            }
        }
    }
}
