using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martography.Areas.Administration.Controllers
{
    public class BlogController : AdministrationController
    {
        public IActionResult ById(string id)
        {
            return View();
        }

        public IActionResult Edit(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(string htmlContent)
        {
            return View();
        }
    }
}
