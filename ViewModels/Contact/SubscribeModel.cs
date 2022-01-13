using System.ComponentModel.DataAnnotations;

namespace ViewModels.Contact
{
    public class SubscribeModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$", ErrorMessage = "Please make sure your email address is valid")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Your Name must be between 3 and 100 characters long")]
        public string Name { get; set; }
    }
}
