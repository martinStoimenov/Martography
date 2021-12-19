using Data.Models;
using Services.Mapping;
using System.Collections.Generic;
using ViewModels.Images;

namespace ViewModels.ProjectModels
{
    public class ProjectViewModel : IMapFrom<Project>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
