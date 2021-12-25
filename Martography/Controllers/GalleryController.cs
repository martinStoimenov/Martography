using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
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
            gallery.GalleryDropDowns = galleryService.GetAllGalleriesCached<GalleryDropDownViewModel>();

            TempData["PreviousGalleryId"] = Request.Headers["Referer"].ToString().Split("/").Last();

            return View(gallery);
        }
    }
}
