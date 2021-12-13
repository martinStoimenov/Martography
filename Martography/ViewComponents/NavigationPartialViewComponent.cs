using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;

namespace Martography.ViewComponents
{
    public class NavigationPartialViewComponent : ViewComponent
    {
        private readonly IGalleryService galleryService;

        public NavigationPartialViewComponent(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }
        public IViewComponentResult Invoke()
        {
            var galleries = galleryService.GetAllGalleriesCached();
            return View(galleries);
        }
    }
}
