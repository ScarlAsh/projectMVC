using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewDescription { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } 

    }
}
