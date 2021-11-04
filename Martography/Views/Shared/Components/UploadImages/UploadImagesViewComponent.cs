using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Martography.Views.Shared.Components.UploadImages
{
    public class UploadImagesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return View();
        }
    }
}
