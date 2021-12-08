using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martography.Areas.Administration.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    [IgnoreAntiforgeryToken]
    public class AdminApiController : AdministrationController
    {
        private readonly IGalleryService galleryService;
        private readonly IImageService imagesService;

        public AdminApiController(IGalleryService galleryService, IImageService imagesService)
        {
            this.galleryService = galleryService;
            this.imagesService = imagesService;
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

        [HttpGet(nameof(GalleryUpdate))]
        public async Task<IActionResult> GalleryUpdate()
        {
            var a = 0;
            return Ok("Gallery Update GET retun");
        }

        [HttpPost(nameof(EditImages))]
        public async Task<IActionResult> EditImages(IEnumerable<EditImagesModel> images)
        {
            if(images == null || images.Count() <= 0)
            {
                return Content("There was no images :(");
            }

            // TODO:
            //imagesService.UpdateImages(images);

            return Ok();
        }

        public class UpdateGalleryModel
        {
            public string name { get; set; }
            public string description { get; set; }
            public string id { get; set; }
            public bool isDeleted { get; set; }
            public bool isPrivate { get; set; }
        }

        public class EditImagesModel
        {
            public string Id { get; set; }
            public string Description { get; set; }
            public bool IsThumbnail { get; set; }
            public bool IsOnHomePageCarousel { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
