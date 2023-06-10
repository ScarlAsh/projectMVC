using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectMVC.Models;
using System.ComponentModel;
using System.Reflection.Emit;

namespace projectMVC.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<Order> Orders { get; set; }

		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Brand> Brands { get; set; }

		public virtual DbSet<Review> Reviews { get; set; }

		public virtual DbSet<CartItem> CartItems { get; set; }

		public virtual DbSet<WishListItem> WishListItems { get; set; }

		public virtual DbSet<OrderItems> OrderItems { get; set; }

		public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<StoreReview> StoreReviews { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

		public ApplicationDbContext() : base() { }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

		}


		protected override void ConfigureConventions(ModelConfigurationBuilder builder)
		{
			builder.Properties<DateOnly>()
				.HaveConversion<DateOnlyConverter>()
				.HaveColumnType("date");
		}
	}

	public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
	{
		/// <summary>
		/// Creates a new instance of this converter.
		/// </summary>
		public DateOnlyConverter() : base(
				d => d.ToDateTime(TimeOnly.MinValue),
				d => DateOnly.FromDateTime(d))
		{ }
	}

}
