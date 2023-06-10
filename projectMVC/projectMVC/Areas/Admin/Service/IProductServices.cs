using projectMVC.Models;

namespace projectMVC.Areas.Admin.Service
{
    public interface IProductServices
    {
        List<Product> Pagination(IEnumerable<Product> products, int pageNumber);
		IQueryable<Product> FilterSeachProduct(string search);
	}
}
