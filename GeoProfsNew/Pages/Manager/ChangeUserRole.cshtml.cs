using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoProfsNew.Models;

namespace GeoProfsNew.Pages.Manager
{
    public class ChangeUserRoleModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ChangeUserRoleModel(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public string Role { get; set; }

        public List<SelectListItem> AllUsers { get; set; }
        public List<SelectListItem> AllRoles { get; set; }

        public void OnGet()
        {
            // Populate the Users dropdown
            AllUsers = _userManager.Users.Select(u => new SelectListItem { Value = u.Id, Text = u.UserName }).ToList();

            // Populate the Roles dropdown
            AllRoles = _roleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return Page();
            }

            // Remove existing roles and add the selected role
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, Role);

            TempData["SuccessMessage"] = $"Role for {user.UserName} changed to {Role}";
            return RedirectToPage("/Manager/ChangeUserRole");
        }
    }
}
