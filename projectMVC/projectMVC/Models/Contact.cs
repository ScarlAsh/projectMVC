using System.ComponentModel.DataAnnotations;

namespace projectMVC.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is Required")]

        public string Message { get; set; }
    }
}
