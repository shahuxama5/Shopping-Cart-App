using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models;
using System.Threading.Tasks;

namespace ShoppingCartApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController (UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
        }

        // Get / Account / Register
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Post / Account / Register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(user);
        }

        // Get / Account / Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login()
            {
                ReturnUrl = returnUrl
            };

            return View(login);
        }

        // Post / Account / Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);

                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(login.ReturnUrl ?? "/");
                    }
                }

                ModelState.AddModelError("", "Login failed, wrong credentials.");
            }

            return View(login);
        }

        // Get / Account / Logout
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Redirect("/");
        }

        // Get / Account / Edit
        [AllowAnonymous]
        [HttpGet] 
        public async Task<IActionResult> Edit()
        {
            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
            UserEdit user = new UserEdit(appUser);
            return View(user);
        }

        // Post / Account / Edit
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEdit user)
        {
            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);

            if (ModelState.IsValid)
            {
                appUser.Email = user.Email;

                if (user.Password != null)
                {
                    appUser.PasswordHash = passwordHasher.HashPassword(appUser, user.Password);
                }

                IdentityResult result = await userManager.UpdateAsync(appUser);

                if (result.Succeeded)
                {
                    TempData["Success"] = "Yor information has been edited!";
                }
            }

            return View();
        }


    }
}
