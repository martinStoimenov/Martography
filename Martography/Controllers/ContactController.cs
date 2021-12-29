using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System.Threading.Tasks;
using ViewModels.Contact;

namespace Martography.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService emailService;

        public ContactController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(ContactFormViewModel model)
        {
            var isSuccessfull = await emailService.Send(model.Email, model.Subject, model.Message, model.Name);

            return View("ContactFormSubmissionConfirmation", isSuccessfull);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Index", "Home");

            var isSuccessfull = await emailService.CreateContact(email);

            return Content($"{isSuccessfull}");
        }
    }
}
