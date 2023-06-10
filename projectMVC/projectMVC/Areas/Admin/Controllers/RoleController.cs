using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectMVC.ViewModels;
using System.Data;

namespace projectMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
           
        }

        public IActionResult Index()
        {
            var data = _roleManager.Roles.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addRole(RoleVM role)
        {
            if (ModelState.IsValid == true)
            {
                IdentityRole Role = new() { Name = role.RoleName };

                IdentityResult result = await _roleManager.CreateAsync(Role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return RedirectToAction("Index" , "Role");
        }
    }
}
