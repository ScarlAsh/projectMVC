using projectMVC.Models;
using projectMVC.UnitOfWork;

namespace projectMVC.Service
{
    public class ShopService:IShopService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public List<Product> Pagination(IEnumerable<Product> products, int pageNumber ) 
        //{
        //    var pageProduct = products.Skip((pageNumber - 1) * 9) //
        //                        .Take(pageNumber * 9).ToList(); //
        //    return pageProduct;
        //}



		public IQueryable<Product> FilterSeachProduct(string search, List<string> categories, List<string> Brands)
		{
			var pipline = _unitOfWork.Product.GetAll();

			if (categories.Count > 0 && Brands.Count > 0)
			{
				pipline = pipline.Where(p => categories.Contains(p.Category.Name) && Brands.Contains(p.Brand.Name));
			}
			else if (categories.Count > 0 && Brands.Count == 0)
			{
				pipline = pipline.Where(p => categories.Contains(p.Category.Name));

			}
			else if (categories.Count == 0 && Brands.Count > 0)
			{
				pipline = pipline.Where(p => Brands.Contains(p.Brand.Name));

			}

			if (!string.IsNullOrEmpty(search))
			{
				pipline = pipline.Where(p => p.Name.Contains(search));
			}
			return pipline;
		}



	}



}
