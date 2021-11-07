using Data.Models;
using Services.Mapping;
using System;

namespace Martography.ViewModels.GalleryModels
{
    public class SingleGalleryViewModel : IMapFrom<Gallery>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
