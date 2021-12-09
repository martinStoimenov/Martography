using Data.Models;
using Services.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using ViewModels.GalleryModels;
using ViewModels.Images;

namespace ViewModels.ProjectModels
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
        public IEnumerable<ImageViewModel> Images { get; set; }
        public IEnumerable<GalleryDropDownViewModel> AllGalleries { get; set; }
    }
}
