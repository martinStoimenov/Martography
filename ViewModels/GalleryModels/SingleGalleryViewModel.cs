using Data.Models;
using Services.Mapping;
using System;
using System.Collections.Generic;
using ViewModels.ProjectModels;

namespace ViewModels.GalleryModels
{
    public class SingleGalleryViewModel : IMapFrom<Gallery>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
        public IEnumerable<GalleryDropDownViewModel> GalleryDropDowns { get; set; }
    }
}
