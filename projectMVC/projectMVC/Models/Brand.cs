using projectMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class Brand
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Category> Categories { get; set; }
	}
}
