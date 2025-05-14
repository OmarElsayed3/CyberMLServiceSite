using CyberMLServiceSite.Core.Models;
using CyberMLServiceSite.Data;
using CyberMLServiceSite.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace CyberMLServiceSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Applicationuser> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private object userManager;

        public AdminController(ApplicationDbContext context, UserManager<Applicationuser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Requests()
        {
            var requests = await _context.serviceRequests
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();

            return View(requests);
        }

        [HttpGet]
        public  IActionResult Users()
        {
            var users = _context.Users.ToList();
            var usersmodel = new List<UserViewModel>();
            foreach(var item in users)
            {
                var newuser = new UserViewModel()
                {
                    UserName = item.UserName,
                    Email = item.Email
                };
                usersmodel.Add(newuser);
                
            }

            return View(usersmodel);
        }


        public IActionResult Roles()
        {
            var roles = roleManager.Roles.ToList();
            var roleViewModels = roles.Select(role => new RoleViewModel
            {
                RoleName = role.Name
            }).ToList();

            return View(roleViewModels);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRole)
        {
            if (!ModelState.IsValid)
            {
                return View("AddRole", newRole);
            }

            var existingRole = await roleManager.FindByNameAsync(newRole.RoleName);
            if (existingRole != null)
            {
                ModelState.AddModelError("", "This role already exists");
                return View("AddRole", newRole);
            }

            var role = new IdentityRole { Name = newRole.RoleName };
            var result = await roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("AddRole", newRole);
        }


    }
}
