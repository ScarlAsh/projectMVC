using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectMVC.Models;
using projectMVC.ViewModels;
using System.Security.Claims;

namespace projectMVC.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
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
                    await _signInManager.SignInAsync(User, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(registerViewModel);

        }

        public IActionResult Login(string ReturnUrl = "/Home/Index")
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string ReturnUrl = "/Home/Index")
        {
            if (ModelState.IsValid == true)
            {
                var User = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (User != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await _signInManager.PasswordSignInAsync(User, loginViewModel.Password, loginViewModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if(await _userManager.IsInRoleAsync( User , "Admin"))
                        {
                            return RedirectToAction("Index" , "Home" , new {area="Admin"});
                        }
                        return LocalRedirect(ReturnUrl);
                    }
                    ModelState.AddModelError("", " Password is incorrect");
                }
                else
                    ModelState.AddModelError("", "Email or Password is incorrect");

            }
            
            return View(loginViewModel);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

     



    }


}
