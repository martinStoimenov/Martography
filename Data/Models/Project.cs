using Data.Common;
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Project : BaseDeletableModel<string>
    {
        public Project()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<Image>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GalleryId { get; set; }
        public Gallery Gallery { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
