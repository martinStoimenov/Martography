using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Martography.Views.Shared.Components.Gallery
{
    public class GalleryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
