﻿using System.ComponentModel.DataAnnotations;

namespace ViewModels.Contact
{
    public class ContactFormViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$", ErrorMessage = "Please make sure your email address is valid")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Your Name must be between 3 and 100 characters long")]
        public string Name { get; set; }
        [Required]
        [StringLength(2500, MinimumLength = 3, ErrorMessage = "Your Message must be between 3 and 2500 characters long")]
        public string Message { get; set; }
        [MaxLength(250, ErrorMessage = "Subject must be below 250 characters")]
        public string Subject { get; set; }
    }
}
