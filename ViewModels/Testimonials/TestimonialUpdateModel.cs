namespace ViewModels.Testimonials
{
    public class TestimonialUpdateModel
    {
        public string Id { get; set; }
        public bool IsVisible { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageId { get; set; }
    }
}
