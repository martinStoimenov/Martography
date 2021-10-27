using System;

namespace Data.Models
{
    public class Testimonials
    {
        public Testimonials()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Content { get; set; }
        public string PersonName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }

        //public string ImageId { get; set; }
        //public Image Image { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
