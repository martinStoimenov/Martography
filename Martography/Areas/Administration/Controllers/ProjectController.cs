using ViewModels.Images;
using ViewModels.ProjectModels;
using Services.Data.Interfaces;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Linq;

namespace Martography.Areas.Administration.Controllers
{
    public class ProjectController : AdministrationController
    {
        private readonly IProjectsService projectsService;
        private readonly IImageService imageService;

        public ProjectController(IProjectsService projectsService, IImageService imageService)
        {
            this.projectsService = projectsService;
            this.imageService = imageService;
        }

        public async Task<IActionResult> Index(string id)
        {
            var singleProject = await projectsService.GetProjectByIdForAdmin<SingleProjectViewModel>(id);
            
            return View(singleProject);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ImagesUploadViewModel model)
        {
            var imagesList = new List<ImageUploadViewModel>();

            foreach (var i in model.Images)
            {
                imagesList.Add(new ImageUploadViewModel()
                {
                    Name = i.FileName,
                    GalleryName = model.galleryName,
                    ProjectName = model.projectName,
                    Type = i.ContentType,
                    Content = i.OpenReadStream()
                });
            }
            //Upload to the File System
            await imageService.SaveImageToFileSystem(imagesList);

            foreach (var image in model.Images)
            {
                //Upload to the databse
                await imageService.InsertImage(image.FileName, model.projectId);
            }

            return RedirectToAction(nameof(this.Index), new { id = model.projectId });
        }

        public async Task<IActionResult> Edit(string projectId)
        {
            var singleProject = await projectsService.GetProjectByIdForAdmin<SingleProjectViewModel>(projectId);

            return View(singleProject);
        }
    }
}
