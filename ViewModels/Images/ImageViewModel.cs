using Data.Models;
using Services.Mapping;

namespace ViewModels.Images
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsProjectThumbnail { get; set; }
        public bool ShowOnHomePageCarousel { get; set; }
        public string ProjectGalleryName { get; set; }
        public string ProjectName { get; set; }
        public string ImageBaseUrl { get => string.Join("/", new string[] { Common.GlobalConstants.BaseImagesFolder, ProjectGalleryName, ProjectName, Url }); set { } }
    }
}
