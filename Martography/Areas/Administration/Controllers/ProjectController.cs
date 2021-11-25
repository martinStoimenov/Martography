using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Images;
using ViewModels.ProjectModels;

namespace Martography.Areas.Administration.Controllers
{
    public class ProjectController : AdministrationController
    {
        private readonly IProjectsService projectsService;

        public ProjectController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        public async Task<IActionResult> Index(string id)
        {
            var model = new ProjectModel()
            {
                singleProject = await projectsService.GetProjectByIdForAdmin<SingleProjectViewModel>(id)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IEnumerable<ImagesUploadViewModel> model)
        {
            // FIX THE model
            var res = new ProjectModel()
            {
                //singleProject = await projectsService.GetProjectByIdForAdmin<SingleProjectViewModel>(id)
            };
            return View();
        }
    }
}
