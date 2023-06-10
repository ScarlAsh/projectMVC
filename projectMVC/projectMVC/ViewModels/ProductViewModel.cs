using projectMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.ViewModels
{
    public class ProductViewModel
    {
        
        public double Price { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public string Description { get; set; }
        
        public int UnitsInStock { get; set; }
        public DateTime RealseDate { get; set; }
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }

        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public List<string> info { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        
    }
}
