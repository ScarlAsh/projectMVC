using System.ComponentModel.DataAnnotations.Schema;

namespace projectMVC.Models
{
	public class StoreReview
	{
		public int Id { get; set; }
		public string ReviewDescription { get; set; }
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual ApplicationUser User { get; set; }
	}
}
