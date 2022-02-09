using Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Mapping;
using System;
using System.Collections.Generic;

namespace Martography.Areas.Administration.ViewModels
{
    public class BlogPostAdminViewModel : IMapFrom<BlogPost>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string GalleryId { get; set; }
        public string ImageId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IEnumerable<AdminImageDropdownViewModel> AllImages { get; set; }
        public List<SelectListItem> AllGalleries { get; set; }
    }
}
