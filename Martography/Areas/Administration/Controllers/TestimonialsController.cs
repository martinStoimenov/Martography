 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Testimonials;

namespace Martography.Areas.Administration.Controllers
{
    public class TestimonialsController : AdministrationController
    {
        private readonly ITestimonialService service;

        public TestimonialsController(ITestimonialService service)
        {
            this.service = service;
        }

        // GET: TestimonialsController
        public async Task<ActionResult> Index()
        {
            var testimonials = await service.GetAllForAdmin<TestimonialsAdminModel>();
            return View(testimonials);
        }

        // GET: TestimonialsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestimonialsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestimonialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestimonialsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestimonialsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(List<TestimonialsAdminModel> model)
        {
            try
            {
                await service.EditForAdmin(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestimonialsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestimonialsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    public class UpdateModel
    {
        public IEnumerable<TestimonialsAdminModel> testimonial { get; set; }
    }
}
