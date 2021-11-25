using Common.ValidationAttributes;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Services.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Images
{
    public class ImagesUploadViewModel : IMapTo<Image>
    {
        [Required]
        [MaxFileSize(24 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IEnumerable<IFormFile> Image { get; set; }
    }
}
