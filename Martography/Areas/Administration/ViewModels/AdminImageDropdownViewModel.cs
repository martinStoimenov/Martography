using Data.Models;
using Services.Mapping;

namespace Martography.Areas.Administration.ViewModels
{
    public class AdminImageDropdownViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProjectGalleryName { get; set; }
        public string ProjectGalleryId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public string FullSizeImageUrl { get => string.Join("/", new string[] { Common.GlobalConstants.BaseImagesFolder, ProjectGalleryName, ProjectName, Name }); set { } }
        public string ThumbnailImageUrl { get => string.Join("/", new string[] { Common.GlobalConstants.BaseImagesFolder, ProjectGalleryName, ProjectName, $"{Common.GlobalConstants.ThumbnailPrefix}{Name}" }); set { } }
    }
}
