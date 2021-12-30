using System;
using Data.Common;

namespace Data.Models
{
    public class BlogPost : BaseDeletableModel<string>
    {
        public BlogPost()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string GalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}
