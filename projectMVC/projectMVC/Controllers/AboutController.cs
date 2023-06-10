using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectMVC.Models;
using projectMVC.UnitOfWork;
using System.Security.Claims;

namespace projectMVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

		public AboutController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
        {
            //var Reviews = _unitOfWork.StoreReview.GetAll().ToList();
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Index(string messageReivew)
        {
            if(!string.IsNullOrEmpty(messageReivew))
            {
                _unitOfWork.StoreReview.Create(new StoreReview
                {
                    ReviewDescription = messageReivew,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                });
            }
            var Reviews = _unitOfWork.StoreReview.GetAll().ToList();
            return View(Reviews);
        }
    }
}
