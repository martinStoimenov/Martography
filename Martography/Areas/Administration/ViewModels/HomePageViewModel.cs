using System.Collections.Generic;
using ViewModels.GalleryModels;
using ViewModels.ProjectModels;
using ViewModels.Blog;

namespace Martography.Areas.Administration.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<SingleGalleryViewModel> Galleries { get; set; }
        public IEnumerable<AdminProjectViewModel> Projects { get; set; }
        public IEnumerable<AllBlogPostsAdminViewModel> BlogPosts { get; set; }
    }
}