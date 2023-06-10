using projectMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class Category
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Brand> Brands { get; set; }


	}
}
