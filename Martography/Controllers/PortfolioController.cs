using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.ProjectModels;

namespace Martography.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectsService projectsService;

        public PortfolioController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await projectsService.GetAllProjects<ProjectViewModel>();
            return View(model);
        }
    }
}
