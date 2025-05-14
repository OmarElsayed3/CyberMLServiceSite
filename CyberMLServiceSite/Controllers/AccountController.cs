using CyberMLServiceSite.Core.Models;
using CyberMLServiceSite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CyberMLServiceSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly SignInManager<Applicationuser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<Applicationuser> userManager, SignInManager<Applicationuser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel uservm)
        {
            if (ModelState.IsValid)
            {
                // Check if user already exists
                var existingUser = await userManager.FindByNameAsync(uservm.username);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "username is already registered");
                    return View(uservm);
                }
                Applicationuser user = new Applicationuser()
                {
                    UserName = uservm.username,
                    Email = uservm.Email,
                };
               
                IdentityResult res = await userManager.CreateAsync(user, uservm.Password);
                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await signInManager.SignInAsync(user, false);
                    TempData["LoginSuccess"] = "Sign in successful! Welcome to  Strike Defender.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var erorr in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, erorr.Description);
                    }
                }

            }

            return View(uservm);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel uservm)
        {
            if (ModelState.IsValid)
            {
                Applicationuser user = await userManager.FindByNameAsync(uservm.username);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, uservm.password);
                    if (found)
                    {
                        await signInManager.SignInAsync(user, uservm.RememberMe);
                        TempData["LoginSuccess"] = "Login successful! Welcome to  Strike Defender.";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password Wrong");
                    }
                }
                ModelState.AddModelError("", "Username  Wrong");
            }

            return View(uservm);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData["LogoutSuccess"] = "Log Out successful!";
            return RedirectToAction("Login");
        }
    }
}
