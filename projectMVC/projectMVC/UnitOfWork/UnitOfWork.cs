
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Data;
using projectMVC.UnitOfWork;
using projectMVC.Models;
using projectMVC.Generic_Repository.Services;

namespace projectMVC.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Product = new GenericRepository<Product>(_context);
            Category = new GenericRepository<Category>(_context);
            Brand = new GenericRepository<Brand>(_context);
			CartItem = new GenericRepository<CartItem>(_context);
			Order = new GenericRepository<Order>(_context);
			OrderItem = new GenericRepository<OrderItems>(_context);
			WishListItem = new GenericRepository<WishListItem>(_context);
        }
        public IGenericRepository<Product> Product { get; set; }
        public IGenericRepository<Category> Category { get; set; }

        public IGenericRepository<Brand> Brand {get;set; }

        public IGenericRepository<Contact> Contact { get; set; }

        public IGenericRepository<Image> image { get; set; }
        public IGenericRepository<StoreReview> StoreReview { get; set; }
		public IGenericRepository<CartItem> CartItem { get; set; }
		public IGenericRepository<Order> Order { get; set; }
		public IGenericRepository<OrderItems> OrderItem { get; set; }

        public IGenericRepository<WishListItem> WishListItem { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
