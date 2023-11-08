using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.LeaveRequests
{
    public class CreateModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public CreateModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ReasonTypes = _context.Reasons
                  .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                  .ToList();

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

            _context.LeaveRequests.Add(LeaveRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./../Shared/_Layout");
        }
    }
}
