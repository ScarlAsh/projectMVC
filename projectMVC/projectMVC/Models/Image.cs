using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product product { get; set; }
    }
}
