using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModels.ProjectModels;

namespace Martography.Views.Shared.Components.Gallery
{
    public class GalleryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string galleryId)
        {
            return View();
        }
    }
}
