using System.Collections.Generic;

namespace Martography.Areas.Administration.ViewModels
{
    public class TestimonialAdminPageModel
    {
        public List<TestimonialsAdminModel> Testimonials { get; set; }
        public IEnumerable<AdminImageDropdownViewModel> AllImages { get; set; }
    }
}
