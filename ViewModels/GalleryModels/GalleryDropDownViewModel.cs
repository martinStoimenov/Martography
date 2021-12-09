using Data.Models;
using Services.Mapping;

namespace ViewModels.GalleryModels
{
    public class GalleryDropDownViewModel : IMapFrom<Gallery>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
