using Data.Models;
using Services.Mapping;
using System.IO;

namespace ViewModels.Images
{
    public class ImageUploadViewModel
    {
        public string Name { get; set; }
        public string GalleryName { get; set; }
        public string ProjectName { get; set; }
        public string Type { get; set; }
        public Stream Content { get; set; }
    }
}
