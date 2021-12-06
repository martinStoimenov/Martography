using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ViewModels.GalleryModels;
using ViewModels.ProjectModels;

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
    }

    public class HomePageViewModel
    {
        public IEnumerable<SingleGalleryViewModel> Galleries { get; set; }
        public IEnumerable<SingleProjectViewModel> Projects { get; set; }
    }
}
