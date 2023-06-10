using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;
using projectMVC.ViewModels;

namespace projectMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IGenericRepository<ApplicationUser> _genericRepository;
		private readonly UserManager<ApplicationUser> _userManager;

		public AdminController(IGenericRepository<ApplicationUser> genericRepository, UserManager<ApplicationUser> userManager)
		{
			_genericRepository = genericRepository;
			_userManager = userManager;
		}


		public async Task<IActionResult> Index()
        {
            var data = _genericRepository.GetAll().ToList();
            List<ApplicationUser> Admins = new();
            foreach (var item in data )
            {
                if (await _userManager.IsInRoleAsync(item , "Admin"))
                {
                    Admins.Add(item);
                    
                }    
            }

            return View(Admins);
        }


        public IActionResult addAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addAdmin(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser User = new ApplicationUser();
                User.FirstName = registerViewModel.FirstName;
                User.LastName = registerViewModel.LastName;
                User.Email = registerViewModel.Email;
                User.UserName = registerViewModel.UserName;
                var result = await _userManager.CreateAsync(User, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(User , "Admin");
                    return RedirectToAction("Index", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(registerViewModel);
        }
    }
}
