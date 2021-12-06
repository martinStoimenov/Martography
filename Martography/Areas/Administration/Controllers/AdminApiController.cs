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

        public AdminApiController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
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

        public class UpdateGalleryModel
        {
            public string name { get; set; }
            public string description { get; set; }
            public string id { get; set; }
            public bool isDeleted { get; set; }
            public bool isPrivate { get; set; }
        }
    }
}
