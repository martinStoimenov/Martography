namespace ViewModels.Images
{
    public class ImagesInProjectUpdateModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int? Position { get; set; }
        public bool IsThumbnail { get; set; }
        public bool IsOnHomePageCarousel { get; set; }
        public bool IsOnHomePageGallery { get; set; }
        public bool IsDeleted { get; set; }
    }
}
