using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;
using projectMVC.ViewModels;
using projectMVC.Models;

namespace projectMVC.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Product { get;}
        IGenericRepository<Category> Category { get; }
        IGenericRepository<Brand> Brand{ get; }
        IGenericRepository<Contact> Contact{ get; }
        IGenericRepository<Image> image{ get; }
        IGenericRepository<StoreReview> StoreReview { get; }
		IGenericRepository<CartItem> CartItem { get; }
		IGenericRepository<WishListItem> WishListItem { get; }
		IGenericRepository<Order> Order { get; }
		IGenericRepository<OrderItems> OrderItem { get; }




	}
}
