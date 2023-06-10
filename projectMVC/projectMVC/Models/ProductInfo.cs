using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Info { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
