using System.Collections.Generic;
using ViewModels.Contact;
using ViewModels.Images;

namespace ViewModels.HomePage
{
    public class HomePageViewModel
    {
        public IEnumerable<ImageViewModel> CarouselImages { get; set; }
        public IEnumerable<HomePageCardImageViewModel> GalleryCards { get; set; }
        public SubscribeModel SubscribeModel { get; set; }
    }
}
