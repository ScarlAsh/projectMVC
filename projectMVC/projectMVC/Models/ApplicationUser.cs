using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace projectMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required , MaxLength(50)]
        public string FirstName { get; set; }

        [Required , MaxLength(50)]
        public string LastName { get; set; }
        public virtual List<WishListItem> WishListItems { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public string Picture { get; set; }


    }
}
