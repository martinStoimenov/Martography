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
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isSuccessfull = await emailService.Send(model.Email, model.Subject, model.Message, model.Name);

            return View("ContactFormSubmissionConfirmation", isSuccessfull);
        }
    }
}
