using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Gallery
    {
        public Gallery()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Projects = new HashSet<Project>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
