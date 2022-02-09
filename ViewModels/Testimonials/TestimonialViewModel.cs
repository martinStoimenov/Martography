using Services.Mapping;
using System.ComponentModel.DataAnnotations;
using ViewModels.Images;

namespace ViewModels.Testimonials
{
    public class TestimonialViewModel : IMapFrom<Data.Models.Testimonial>
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public string PersonName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public bool IsVisible { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public bool IsApproved { get; set; }
        public ImageViewModel Image { get; set; }
    }
}
