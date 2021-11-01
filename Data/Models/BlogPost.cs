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
    }
}
