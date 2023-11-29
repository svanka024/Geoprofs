using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfsNew.Models;
using GeoProfsNew.Data;

namespace GeoProfsNew.Pages.LeaveRequests
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LeaveRequest> LeaveRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.LeaveRequests != null)
            {
                LeaveRequest = await _context.LeaveRequests.Include(lr => lr.Reason).Include(lr => lr.Status).ToListAsync();
        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                User = await _context.Users.ToListAsync();
            }
        }
    }
}
