using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public ProjectController(IProjectsService projectsService, IConfiguration configuration)
        {
            this.projectsService = projectsService;
            this.configuration = configuration;
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
        public async Task<IActionResult> Upload(ImagesUploadViewModel model)
        {
            var cloudinarySection = configuration.GetSection("CloudinaryAPI");
            var apiKey = cloudinarySection.GetValue<string>("APIKey");
            var apiSecret = cloudinarySection.GetValue<string>("APISecret");
            var cloudName = cloudinarySection.GetValue<string>("CloudName");

            Account account = new Account( cloudName, apiKey, apiSecret);

            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
            //var resources = cloudinary.ListResources();
            var res = 0;
            return RedirectToAction(nameof(this.Index), new { id = model.projectId });
        }
    }
}
