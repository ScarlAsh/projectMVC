using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;
using projectMVC.UnitOfWork;
using projectMVC.ViewModels;
using Stripe;
using System.Security.Claims;

namespace projectMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;

		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			var order = _unitOfWork.Order.GetAll().Where(o=>o.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
			return View(order);
		}
		

  //      [HttpPost]
		//[AutoValidateAntiforgeryToken]
        public IActionResult CheckOut(string shippingMethod="10")
        {
			var cartItems = _unitOfWork.CartItem.GetAll().Where(c=>c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
			ViewBag.shippingMethod = shippingMethod;
			return View(cartItems);
        }

		[HttpPost]
		[AutoValidateAntiforgeryToken]

		public IActionResult OrderCompleted(ShippingAddressViewModel shippingAddressViewModel )
		 {
			if(shippingAddressViewModel == null )
			{
				return RedirectToAction("CheckOut");
			}
			var order = _unitOfWork.Order.Create(new Order
						{
							BuyerEmail = shippingAddressViewModel.BuyerEmail,
							ShipToAddress_FirstName = shippingAddressViewModel.ShipToAddress_FirstName,
							ShipToAddress_LastName = shippingAddressViewModel.ShipToAddress_LastName,
							ShipToAddress_City = shippingAddressViewModel.ShipToAddress_City,
							ShipToAddress_State = shippingAddressViewModel.ShipToAddress_State,
							ShipToAddress_Street = shippingAddressViewModel.ShipToAddress_Street,
							ShipToAddress_ZipCode = shippingAddressViewModel.ShipToAddress_ZipCode,
							ShipToAddress_PhoneNumber = shippingAddressViewModel.ShipToAddress_PhoneNumber,
							TotalPrice = (double)shippingAddressViewModel.TotalPrice,
							OrderDate = DateTime.Now,
							UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
			});
			var cartItems = _unitOfWork.CartItem.GetAll().Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
			foreach (var item in cartItems)
			{
				_unitOfWork.OrderItem.Create(new OrderItems
				{
					OrderId = order.Id,
					ProductId = item.ProductId,
					Price = (decimal)(item.Product.Price * item.Quantity),
					Quantity = item.Quantity,
					
				});
			}
			
			return View();
		 }
		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult OrderDetails(int id)
		{	
			var Order = _unitOfWork.Order.GetById(id);
			return View(Order);
		}

    }
}

