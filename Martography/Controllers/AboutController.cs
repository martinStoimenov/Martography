using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.About;
using ViewModels.Testimonials;

namespace Martography.Controllers
{
    public class AboutController : Controller
    {
        private readonly ITestimonialService service;

        public AboutController(ITestimonialService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var model = new AboutPageViewModel()
            {
                AllTestimonials = await service.GetAllApproved<TestimonialViewModel>()
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AboutPageViewModel aboutPageModel)
        {
            if (!ModelState.IsValid)
                return View();

            await service.Create(aboutPageModel.TestimonialFormModel.PersonName, 
                aboutPageModel.TestimonialFormModel.Company, aboutPageModel.TestimonialFormModel.Position, 
                aboutPageModel.TestimonialFormModel.EmailAddress, aboutPageModel.TestimonialFormModel.Content);

            return RedirectToAction(nameof(this.Index));
        }
    }
}
