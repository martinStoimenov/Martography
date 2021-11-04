using Microsoft.AspNetCore.Mvc;

using CloudinaryDotNet;
using Services.Data.Interfaces;
using System.Threading.Tasks;
using Martography.ViewModels.Project;

namespace Martography.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        private readonly IGalleryService galleryService;

        public HomeController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }
        public async Task<IActionResult> Index()
        {
            //var cloudinary = new Cloudinary();
            //cloudinary.Api.ApiUrl.BuildUrl();

            var res = await galleryService.GetAllForPublicGallery<ProjectsListViewModel>("galleyId here");

            return View();
        }

        public IActionResult GetUploadImagesComponent()
        {
            return ViewComponent("UploadImages");
        }
        public IActionResult GetGalleryComponent()
        {
            return ViewComponent("Gallery");
        }
    }
}
