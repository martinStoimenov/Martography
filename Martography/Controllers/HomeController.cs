using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Data.Interfaces;
using System.Threading.Tasks;

namespace Martography.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageService imageService;

        public HomeController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            // return model with images that should be on the home screen carousel first (and/or images from a project)
            // gallery of the images below the home screen
            // 3 projects (galleries)
            return View();
        }
    }
}
