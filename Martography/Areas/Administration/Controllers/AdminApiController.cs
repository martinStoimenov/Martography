using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Images;

namespace Martography.Areas.Administration.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    [IgnoreAntiforgeryToken]
    public class AdminApiController : AdministrationController
    {
        private readonly IGalleryService galleryService;
        private readonly IImageService imagesService;
        private readonly IProjectsService projectsService;

        public AdminApiController(IGalleryService galleryService, IImageService imagesService, IProjectsService projectsService)
        {
            this.galleryService = galleryService;
            this.imagesService = imagesService;
            this.projectsService = projectsService;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost(nameof(GalleryEdit))]
        public async Task<IActionResult> GalleryEdit(UpdateGalleryModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var res = await galleryService.EditGalleryForAdmin(model.id, model.name, model.description, model.isDeleted, model.isPrivate);
            return Ok(res);
        }

        [HttpPost(nameof(EditImages))]
        public async Task<IActionResult> EditImages(IEnumerable<ImagesInProjectUpdateModel> images)
        {
            if(images == null || images.Count() <= 0)
            {
                return Content("There was no images :(");
            }

            var projId = await imagesService.UpdateImages(images);

            return RedirectToAction("Index", "Project", new { id = projId });
        }

        [HttpPost(nameof(UpdateProject))]
        public async Task<IActionResult> UpdateProject(UpdateProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await projectsService.Edit(model.id, model.name, model.description, model.isDeleted);
            return RedirectToAction("Index", "Home");
        }

        public class UpdateGalleryModel
        {
            public string name { get; set; }
            public string description { get; set; }
            public string id { get; set; }
            public bool isDeleted { get; set; }
            public bool isPrivate { get; set; }
        }

        public class UpdateProjectModel
        {
            public string name { get; set; }
            public string description { get; set; }
            public string id { get; set; }
            public bool isDeleted { get; set; }
        }
    }
}
