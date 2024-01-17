using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfsNew.Data;
using GeoProfsNew.Models;
using Microsoft.AspNetCore.Identity;

namespace GeoProfsNew.Pages.verlofsaldo
{
    public class VerlofSaldoModel : PageModel
    {
        private readonly GeoProfsNew.Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public VerlofSaldoModel(GeoProfsNew.Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<LeaveRequest> LeaveRequest { get; set; } = default!;
        public Dictionary<string, int> VerlofSaldi { get; private set; } = new Dictionary<string, int>();

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Member")) {

                if (_context.LeaveRequests != null)
                {
                    LeaveRequest = await _context.LeaveRequests
                        .Include(lr => lr.User)
                        .Where(lr => lr.User == user)
                        .ToListAsync();


                    //LeaveRequest.OrderByDescending(x => x.User);

                    //LeaveRequest.Select(x => _context.Users.);

                    // Bereken verlofsaldi op basis van de LeaveRequests
                    CalculateVerlofSaldi();

                }
            }
        }

        private void CalculateVerlofSaldi()
        {
            // Hier voeg je je eigen logica toe om de verlofsaldi te berekenen
            // Je kunt bijvoorbeeld loop door LeaveRequest en de saldi berekenen op basis van verloftype en datums.

            foreach (var request in LeaveRequest)
            {
                // Voeg hier logica toe om verlofsaldi te berekenen op basis van verloftype en datums.
                // Bijvoorbeeld: VerlofSaldi[request.EmployeeId] += request.DaysRequested;
            }
        }

    }
}
