using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectMVC.UnitOfWork;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using projectMVC.Models;
using projectMVC.ViewModels;

namespace projectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(IUnitOfWork unitOfWork , UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

		public ActionResult DefaultPage()
		{
			if (User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Home", new { area = "Admin" });
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public async Task<IActionResult> DashBoard()
        {
            var user = await _userManager?.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> DashBoard(UserProfileViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var currentUser = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

                if (viewModel.Picture is not null)
                {
                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "images", "UserImages");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileExtension = Path.GetExtension(viewModel.Picture.FileName).ToLower();
                    string filePath = Path.Combine(folderPath, currentUser.UserName.Trim() + fileExtension);
                    if (!Directory.Exists(filePath))
                    {
                        viewModel.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                        currentUser.Picture = currentUser.UserName.Trim()+fileExtension;
                        await _userManager.UpdateAsync(currentUser);
                    }

                }
                currentUser.FirstName = viewModel.FirstName;
                currentUser.LastName = viewModel.LastName;
                currentUser.Email = viewModel.Email;
                currentUser.UserName = viewModel.UserName;
                if (viewModel.Picture is null)
                    currentUser.Picture = null;
                await _userManager.UpdateAsync(currentUser);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
        public IActionResult Index()
        {
            // New Products 
            var newProducts = _unitOfWork.Product.GetAll().OrderByDescending(o=>o.RealseDate).Take(15).ToList();
            // BestSeller 
            var bestSeller = _unitOfWork.Product.GetAll().OrderByDescending(o => o.UnitsInStock).Take(15).ToList();

            // HotSale 
            var hotSale = _unitOfWork.Product.GetAll().Where(p=>p.Sale > 0).OrderByDescending(o => o.Sale).Take(15).ToList();

            // Trending Products 
            var trendingProducts = _unitOfWork.Product.GetAll()
                                    .OrderByDescending(o => o.RealseDate)
                                    .GroupBy(c => c.CategoryId)
                                    .ToDictionary(g => g.Select(x => x.Category.Name).FirstOrDefault(), g => g.ToList());
            //var categories = _unitOfWork.Category.GetAll().ToList();
            var topSellinProducts = _unitOfWork.Product.GetAll()
                                  .OrderByDescending(o => o.OutOfStock)
                                  .GroupBy(c => c.CategoryId)
                                  .ToDictionary(g => g.Select(x => x.Category.Name).FirstOrDefault(), g => g.ToList());

            ViewBag.newProducts = newProducts;
            ViewBag.bestSeller = bestSeller;
            ViewBag.hotSale = hotSale;
            ViewBag.trendingProducts = trendingProducts;
            ViewBag.topSellinProducts = topSellinProducts;
            ViewBag.Keys = trendingProducts.Keys.ToList();
            //ViewBag.categories = categories;
            return View();
        }

        public IActionResult AllCat()
        {

            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}