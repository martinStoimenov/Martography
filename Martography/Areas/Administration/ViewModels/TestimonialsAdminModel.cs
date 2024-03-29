﻿using Services.Mapping;
using System;

namespace Martography.Areas.Administration.ViewModels
{
    public class TestimonialsAdminModel : IMapFrom<Data.Models.Testimonial>
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string PersonName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public bool IsVisible { get; set; }
        public string EmailAddress { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ImageId { get; set; }
    }
}
