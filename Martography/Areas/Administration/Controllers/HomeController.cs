using Microsoft.AspNetCore.Mvc;

using CloudinaryDotNet;
using Services.Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Martography.ViewModels.GalleryModels;
using Martography.ViewModels.ProjectModels;
using Microsoft.AspNetCore.Authorization;

namespace Martography.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        private readonly IGalleryService galleryService;
        private readonly IProjectsService projectsService;

        public HomeController(IGalleryService galleryService, IProjectsService projectsService)
        {
            this.galleryService = galleryService;
            this.projectsService = projectsService;
        }
        public async Task<IActionResult> Index()
        {
            //var cloudinary = new Cloudinary();
            //cloudinary.Api.ApiUrl.BuildUrl();

            var galleries = await galleryService.GetAllGalleriesForAdmin<SingleGalleryViewModel>();
            var projects = await projectsService.GetAllProjectsForAdmin<SingleProjectViewModel>();

            var viewModel = new HomePageViewModel() { Galleries = galleries, Projects = projects };

            return View(viewModel);
        }

        public IActionResult GetUploadImagesComponent()
        {
            //return ViewComponent("UploadImages");
            return ViewComponent("Gallery");
        }
        public IActionResult GetGalleryComponent()
        {
            return ViewComponent("Gallery");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGallery(string name, string description, string id, bool isDeleted, bool isPrivate)
        {
            var a = 0;
            return Ok();
        }
    }

    public class HomePageViewModel
    {
        public IEnumerable<SingleGalleryViewModel> Galleries { get; set; }
        public IEnumerable<SingleProjectViewModel> Projects { get; set; }
    }
}
