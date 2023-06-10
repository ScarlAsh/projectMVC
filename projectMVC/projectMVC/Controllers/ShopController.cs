using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using projectMVC.Data;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;
using projectMVC.Service;
using projectMVC.UnitOfWork;
using projectMVC.ViewModels;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace projectMVC.Controllers
{
    public class ShopController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
		private readonly IShopService _shopService;
		public ShopController( IUnitOfWork unitOfWork,IShopService shopService )
        {
            _unitOfWork = unitOfWork;
			_shopService = shopService;
		}


		public async Task<IActionResult> Index( int? pageNumber, string? namepro,string category)
		{
			
			int pageSize = 6; //  => Show number of product in page
			IQueryable<Product> filteredProduct;
			if (!string.IsNullOrEmpty(category))
			{
				filteredProduct = _unitOfWork.Product.GetAll().Where(c => c.Category.Name == category);

			}
			else
                filteredProduct = _unitOfWork.Product.GetAll();
		

			var categories = _unitOfWork.Category.GetAll().ToList();
			var Brands = _unitOfWork.Brand.GetAll().ToList();
			ViewBag.cats = categories;
			ViewBag.brands = Brands;
			return View(await PaginationList<Product>.CreateAsync(filteredProduct, pageNumber ?? 1, pageSize));


		}

	

		public async Task<IActionResult> _shopCartItem(int? pageNumber, string Categories, string brands, string search)
		{
			List<string> checkedCategories = new();
			List<string> checkedBrands = new();

			int pageSize = 6; //  => Show number of product in page
			if (Categories is not null && brands is not null)
			{
				checkedCategories = System.Text.Json.JsonSerializer.Deserialize<List<string>>(Categories);
				checkedBrands = System.Text.Json.JsonSerializer.Deserialize<List<string>>(brands);

			}

			var filteredProduct = _shopService.FilterSeachProduct(search, checkedCategories, checkedBrands);


			return View(await PaginationList<Product>.CreateAsync(filteredProduct, pageNumber ?? 1, pageSize));

		}



	}
	
}
