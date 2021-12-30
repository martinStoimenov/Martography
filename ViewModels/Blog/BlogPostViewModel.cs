using Data.Models;
using Services.Mapping;
using System;
using ViewModels.Images;

namespace ViewModels.Blog
{
    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string GalleryId { get; set; }
        public string GalleryName { get; set; }
        public string ImageId { get; set; }
        public ImageViewModel Image { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
