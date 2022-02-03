using System.Collections.Generic;
using ViewModels.Testimonials;

namespace ViewModels.About
{
    public class AboutPageViewModel
    {
        public TestimonialViewModel TestimonialFormModel { get; set; }
        public IEnumerable<TestimonialViewModel> AllTestimonials { get; set; }
    }
}
