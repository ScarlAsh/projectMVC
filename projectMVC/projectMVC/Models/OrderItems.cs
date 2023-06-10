using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }

    }
}
