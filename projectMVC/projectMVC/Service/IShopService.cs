using projectMVC.Models;

namespace projectMVC.Service
{
    public interface IShopService
    {
        //List<Product> Pagination(IEnumerable<Product> products, int pageNumber);
		IQueryable<Product> FilterSeachProduct(string search, List<string> categories, List<string> Brands);
	}
}
