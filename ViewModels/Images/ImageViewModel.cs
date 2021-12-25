using Data.Models;
using Services.Mapping;

namespace ViewModels.Images
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsProjectThumbnail { get; set; }
        public bool ShowOnHomePageCarousel { get; set; }
        public bool ShowOnHomePageGallery { get; set; }
        public bool IsDeleted { get; set; }
        public string ProjectGalleryName { get; set; }
        public string ProjectGalleryId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public int? Position { get; set; }
        public string ImageBaseUrl { get => string.Join("/", new string[] { Common.GlobalConstants.BaseImagesFolder, ProjectGalleryName, ProjectName, Name }); set { } }
        public string ThumbnailImageUrl { get => string.Join("/", new string[] { Common.GlobalConstants.BaseImagesFolder, ProjectGalleryName, ProjectName, $"{Common.GlobalConstants.ThumbnailPrefix}{Name}" }); set { } }
    }
}
