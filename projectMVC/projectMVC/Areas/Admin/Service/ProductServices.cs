using projectMVC.Models;
using projectMVC.UnitOfWork;

namespace projectMVC.Areas.Admin.Service
{
    public class ProductServices: IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Product> Pagination(IEnumerable<Product> products, int pageNumber ) 
        {
            var pageProduct = products.Skip((pageNumber - 1) * 9) //
                                .Take(pageNumber * 9).ToList(); //
            return pageProduct;
        }



		public IQueryable<Product> FilterSeachProduct(string search)
		{
			var pipline = _unitOfWork.Product.GetAll();

			if (!string.IsNullOrEmpty(search))
			{
				pipline = pipline.Where(p => p.Name.Contains(search));
			}
			return pipline;
		}



	}



}
