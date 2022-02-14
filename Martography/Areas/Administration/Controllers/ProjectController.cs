using ViewModels.Images;
using ViewModels.ProjectModels;
using Services.Data.Interfaces;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewModels.GalleryModels;

namespace Martography.Areas.Administration.Controllers
{
    public class ProjectController : AdministrationController
    {
        private readonly IProjectsService projectsService;
        private readonly IImageService imageService;
        private readonly IGalleryService galleryService;

        public ProjectController(IProjectsService projectsService, IImageService imageService, IGalleryService galleryService)
        {
            this.projectsService = projectsService;
            this.imageService = imageService;
            this.galleryService = galleryService;
        }

        public async Task<IActionResult> Index(string id)
        {
            var singleProject = await projectsService.GetProjectByIdForAdmin<AdminProjectViewModel>(id);
            singleProject.AllGalleries = await galleryService.GetAllGalleriesForAdmin<GalleryDropDownViewModel>();

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
            await imageService.SaveImages(imagesList, model.projectId);

            //foreach (var image in model.Images)
            //{
            //    //Upload to the databse
            //    await imageService.InsertImage(image.FileName, model.projectId);
            //}

            return RedirectToAction(nameof(this.Index), new { id = model.projectId });
        }

        public async Task<IActionResult> Edit(string projectId)
        {
            var singleProject = await projectsService.GetProjectByIdForAdmin<AdminProjectViewModel>(projectId);

            return View(singleProject);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeToGallery(string galleryId, string projectId, bool setDeleted)
        {
            if (setDeleted == false)
            {
                await projectsService.UnDeleteProject(projectId);
                await projectsService.MoveProjectToGalleryForAdmin(galleryId, projectId);
            }
            else
            {
                await projectsService.DeleteProject(projectId);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(string name, string galleryId, string description)
        {
            await projectsService.CreateProject(name, description, galleryId);
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> CreateGallery(string name, string description, bool isPrivate)
        {
            await galleryService.CreateGallery(name, description, isPrivate);
            return RedirectToAction("Index","Home");
        }
    }
}
