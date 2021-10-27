using System;

namespace Data.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsProjectThumbnail { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
