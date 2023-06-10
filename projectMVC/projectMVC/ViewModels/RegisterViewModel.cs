using System.ComponentModel.DataAnnotations;

namespace projectMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage ="Passwords don't match, please try again")]
        public string ConfirmPassword { get; set; }

    }
}

