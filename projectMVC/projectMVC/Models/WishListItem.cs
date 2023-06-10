using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class WishListItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        //[ForeignKey("AspNetUsers")]
        //public virtual ApplicationUser User { get; set; }

    }
}
