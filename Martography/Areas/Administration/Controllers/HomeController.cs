using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System.Threading.Tasks;
using ViewModels.GalleryModels;
using ViewModels.ProjectModels;
using ViewModels.Blog;
using Martography.Areas.Administration.ViewModels;

namespace Martography.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        private readonly IGalleryService galleryService;
        private readonly IProjectsService projectsService;
        private readonly IBlogService blogService;

        public HomeController(IGalleryService galleryService, IProjectsService projectsService,
            IBlogService blogService)
        {
            this.galleryService = galleryService;
            this.projectsService = projectsService;
            this.blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var galleries = await galleryService.GetAllGalleriesForAdmin<SingleGalleryViewModel>();
            var projects = await projectsService.GetAllProjectsForAdmin<AdminProjectViewModel>();
            var blogPosts = await blogService.GetAllPostsWithDeletedForAdmin<AllBlogPostsAdminViewModel>();

            var viewModel = new HomePageViewModel() { Galleries = galleries, Projects = projects, BlogPosts = blogPosts };

            return View(viewModel);
        }
    }
}
