using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martography.Controllers
{
    [ApiController]
    [Route("api/Contact")]
    [IgnoreAntiforgeryToken]
    public class ContactApiController : ControllerBase
    {
        private readonly IEmailService emailService;

        public ContactApiController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost(nameof(Subscribe))]
        public async Task<IActionResult> Subscribe(SubscribeModel model)
        {
            if (string.IsNullOrEmpty(model.Email) | string.IsNullOrEmpty(model.Name))
                throw new Exception();

            var isSuccessfull = await emailService.CreateContact(model.Email, model.Name);

            if (isSuccessfull)
                return Ok();
            else
                throw new Exception();
        }
    }

    public class SubscribeModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
