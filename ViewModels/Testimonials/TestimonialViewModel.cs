using System.ComponentModel.DataAnnotations;

namespace ViewModels.Testimonials
{
    public class TestimonialViewModel
    {
        public string Content { get; set; }
        public string PersonName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public bool IsVisible { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public bool IsApproved { get; set; }
    }
}
