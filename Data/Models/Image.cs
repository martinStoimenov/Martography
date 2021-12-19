using Data.Common;
using System;

namespace Data.Models
{
    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsProjectThumbnail { get; set; }
        public bool ShowOnHomePageCarousel { get; set; }
        public int? Position { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
