using Services.Mapping;
using Data.Models;
using System;

namespace Martography.ViewModels.ProjectModels
{
    public class SingleProjectViewModel : IMapFrom<Project>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GalleryName { get; set; }
        public string GalleryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
