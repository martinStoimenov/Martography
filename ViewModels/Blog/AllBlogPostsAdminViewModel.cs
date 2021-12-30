using Data.Models;
using Services.Mapping;
using System;

namespace ViewModels.Blog
{
    public class AllBlogPostsAdminViewModel : IMapFrom<BlogPost>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
