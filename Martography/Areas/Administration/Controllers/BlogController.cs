using Martography.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Data.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.GalleryModels;

namespace Martography.Areas.Administration.Controllers
{
    public class BlogController : AdministrationController
    {
        private readonly IBlogService blogService;
        private readonly IImageService imageService;
        private readonly IGalleryService galleryService;

        public BlogController(IBlogService blogService, 
            IImageService imageService, 
            IGalleryService galleryService)
        {
            this.blogService = blogService;
            this.imageService = imageService;
            this.galleryService = galleryService;
        }

        public async Task<IActionResult> Create()
        {
            var blogpost = new BlogPostAdminViewModel();
            var galleries = galleryService.GetAllGalleriesCached<GalleryDropDownViewModel>();

            blogpost.AllGalleries = galleries.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id, Selected = x.Id == blogpost.Id }).ToList();
            blogpost.AllImages = await imageService.GetAll<AdminImageDropdownViewModel>();
            return View(blogpost);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Content, string Title, string Author, string GalleryId, string ImageId)
        {
            // TODO: Finish the view (add author input images etc. like edit)
            var postId = await blogService.CreatePost(Content, Title, Author, GalleryId, ImageId);
            return await this.Edit(postId);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var blogpost = await blogService.GetPostById<BlogPostAdminViewModel>(id);
            var galleries = galleryService.GetAllGalleriesCached<GalleryDropDownViewModel>();

            blogpost.AllGalleries =  galleries.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id, Selected = x.Id == blogpost.Id }).ToList();
            blogpost.AllImages = await imageService.GetAll<AdminImageDropdownViewModel>();

            return View(blogpost);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, string Content, string Title, string Author, string GalleryId, string ImageId)
        {
            var postId = await blogService.EditPost(Id, Content, Title, Author, GalleryId, ImageId);
            return await this.Edit(postId);
        }
    }
}
