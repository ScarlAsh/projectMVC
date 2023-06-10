using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = "It shouldnot be less than 1")]
        public int Quantity { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
