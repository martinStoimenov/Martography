using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(TestimonialViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            await service.Create(model.PersonName, model.Company, model.Position, model.EmailAddress, model.Content);

            return RedirectToAction(nameof(this.Index));
        }
    }
}
