using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System.Threading.Tasks;
using ViewModels.HomePage;
using ViewModels.Images;
using ViewModels.Testimonials;

namespace Martography.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageService imageService;
        private readonly ITestimonialService testimonialsService;

        public HomeController(IImageService imageService, ITestimonialService testimonialsService)
        {
            this.imageService = imageService;
            this.testimonialsService = testimonialsService;
        }

        public async Task<IActionResult> Index()
        {
            // Testimonials
            var viewModel = new HomePageViewModel()
            {
                CarouselImages = await imageService.GetAllHomePageImages<ImageViewModel>(),
                //GalleryCards = await imageService.GetProjectThumbnails<HomePageCardImageViewModel>(4),
                AllTestimonials = await testimonialsService.GetAllApproved<TestimonialViewModel>()
            };
            return View(viewModel);
        }
    }
}
