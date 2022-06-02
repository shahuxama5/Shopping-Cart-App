using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ShoppingCartApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // Get / Admin / Roles
        [HttpGet]
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        // Get / Admin / Roles / Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Post / Admin / Roles / Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([MinLength(2), Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    TempData["Success"] = "The role has been created!";
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            ModelState.AddModelError("", "Minimum length is 2");

            return View(name);
        }

        // Get / Admin / Roles / Edit / 5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);

            List<AppUser> members = new List<AppUser>();
            List<AppUser> nonMembers = new List<AppUser>();

            foreach (AppUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            return View(new RoleEdit { Role = role, Members = members, NonMembers = nonMembers});
        }

        // Post / Admin / Roles / Edit / 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleEdit roleEdit)
        {
            IdentityResult result ;

            foreach (string userId in roleEdit.AddIds ?? new string[] { })
            {
                AppUser user = await userManager.FindByIdAsync(userId);
                result = await userManager.AddToRoleAsync(user, roleEdit.RoleName);
            }

            foreach (string userId in roleEdit.DeleteIds ?? new string[] { })
            {
                AppUser user = await userManager.FindByIdAsync(userId);
                result = await userManager.RemoveFromRoleAsync(user, roleEdit.RoleName);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
