using Microsoft.AspNetCore.Mvc;

namespace Martography.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
