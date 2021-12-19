﻿using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Data.Interfaces;
using System.Threading.Tasks;
using ViewModels.HomePage;
using ViewModels.Images;

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
            var viewModel = new HomePageViewModel()
            {
                CarouselImages = await imageService.GetAllHomePageImages<ImageViewModel>(),
                GalleryCards = await imageService.GetRandomImagesForHomePageCards<HomePageCardImageViewModel>()
            };
            // 3 projects (galleries) get random image from the current gallery
            // gallery of the images below the home screen
            // Testimonials
            return View(viewModel);
        }
    }
}
