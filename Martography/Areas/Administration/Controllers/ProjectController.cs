using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

            foreach (var image in model.Images)
            {
                var stream = image.OpenReadStream();

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName, stream),
                    PublicId = image.FileName,
                    Folder = string.Join("/", new string[] { Common.GlobalConstants.BaseImagesCloudinaryFolder, Common.GlobalConstants.CloudinaryImagesFolder, model.galleryName, model.projectName }),
                    Overwrite = true
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                if (uploadResult.StatusCode == HttpStatusCode.OK)
                    //Upload the Image to the DB
                    Console.WriteLine("uploaded: " + uploadResult.PublicId);
                else
                    Console.WriteLine("Failed: " + uploadResult.Error);
            }


            var res = 0;
            return RedirectToAction(nameof(this.Index), new { id = model.projectId });
        }
    }
}
