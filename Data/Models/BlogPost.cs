using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
