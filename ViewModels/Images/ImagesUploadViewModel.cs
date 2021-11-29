using Common.ValidationAttributes;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Services.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Images
{
    public class ImagesUploadViewModel
    {
        public string projectId { get; set; }

        [Required]
        [MaxFileSize(24 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
