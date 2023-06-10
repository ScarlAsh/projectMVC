using projectMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace projectMVC.Models
{
	public class Product
	{
		public int Id { get; set; }
		public double Price { get; set; }
		public string Name { get; set; }
		public int Color { get; set; }
		public string Description { get; set; }
		public string ShortDescrition { get; set; }

        public int Sale { get; set; } //

        public int UnitsInStock { get; set; }
		public int OutOfStock { get; set; }
		public DateTime RealseDate { get; set; }
		public virtual List<ProductInfo> ProductInfos { get; set; } = new List<ProductInfo>();
		public virtual List<Image> Images { get; set; } = new List<Image>();
		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		[ForeignKey("Brand")]
		public int BrandId { get; set; }
		public virtual Brand Brand { get; set; }
		public virtual List<Review> reviews { get; set; }

	}
}
