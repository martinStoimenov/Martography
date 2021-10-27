using System.Collections.Generic;

namespace Data.Models
{
    public class Project
    {
        public Project()
        {
            this.Images = new HashSet<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
