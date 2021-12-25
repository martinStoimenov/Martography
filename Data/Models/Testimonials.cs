using Data.Common;
using System;

namespace Data.Models
{
    public class Testimonials : BaseDeletableModel<string>
    {
        public Testimonials()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Content { get; set; }
        public string PersonName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public bool IsVisible { get; set; }
        public string EmailAddress { get; set; }
        public bool IsApproved { get; set; }

        //public string ImageId { get; set; }
        //public Image Image { get; set; }
    }
}
