using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.GalleryModels;

namespace Martography.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryService galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }
        public async Task<IActionResult> Index(string id)
        {
            var gallery = await galleryService.GetGallery<SingleGalleryViewModel>(id);
            gallery.GalleryDropDowns = galleryService.GetAllGalleriesCached<ViewModels.GalleryModels.GalleryDropDownViewModel>();
            return View(gallery);
        }
    }
}
