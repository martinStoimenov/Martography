using Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martography.ViewModels.Project
{
    public class SingleProjectViewModel : IMapFrom<Data.Models.Project>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GalleryId { get; set; }
    }
}
