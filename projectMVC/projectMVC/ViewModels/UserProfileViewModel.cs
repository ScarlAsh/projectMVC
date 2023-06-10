using System.ComponentModel.DataAnnotations;

namespace projectMVC.ViewModels
{
    public class UserProfileViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public IFormFile Picture { get; set; }
    }
}
