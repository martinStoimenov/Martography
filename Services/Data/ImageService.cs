using Data.Models;
using Data.Repositories;
using Services.Data.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ViewModels.Images;
using Image = Data.Models.Image;

namespace Services.Data
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> imageRepository;

        public ImageService(IRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task InsertImage(string imageName, string projectId, bool showOnHomePage = false, bool isProjectThumbnail = false)
        {
            var image = new Image()
            {
                ProjectId = projectId,
                Url = imageName,
                ShowOnHomePageCarousel = showOnHomePage,
                IsProjectThumbnail = isProjectThumbnail
            };

            await imageRepository.AddAsync(image);
            await imageRepository.SaveChangesAsync();
        }

        public async Task SaveImageToFileSystem(IEnumerable<ImageUploadViewModel> images)
        {
            try
            {
                foreach (var image in images)
                {
                    var imageResult = await SixLabors.ImageSharp.Image.LoadAsync(image.Content);

                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        Common.GlobalConstants.BaseImagesFolder,
                        image.GalleryName,
                        image.ProjectName,
                        image.Name);

                    CheckIfGalleryAndProjectDirectoriesExist(image);

                    imageResult.Metadata.ExifProfile = null;
                    await imageResult.SaveAsJpegAsync(path, new JpegEncoder() { Quality = 100 });
                }
            }
            catch (System.Exception error)
            {
                var b = error.Message;
                var a = 0;
                throw;
            }
        }

        /// <summary>
        /// Checks if the paths doesn't exist and creates them.
        /// </summary>
        /// <param name="image"></param>
        private static void CheckIfGalleryAndProjectDirectoriesExist(ImageUploadViewModel image)
        {
            // Gallery
            if (Directory.Exists(Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        Common.GlobalConstants.BaseImagesFolder,
                        image.GalleryName)) == false)
            {
                Directory.CreateDirectory(Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    Common.GlobalConstants.BaseImagesFolder,
                    image.GalleryName,
                    image.ProjectName));
            }

            //Project
            if (Directory.Exists(Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        Common.GlobalConstants.BaseImagesFolder,
                        image.GalleryName,
                        image.ProjectName)) == false)
            {
                Directory.CreateDirectory(Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    Common.GlobalConstants.BaseImagesFolder,
                    image.GalleryName,
                    image.ProjectName));
            }
        }

        public Task UpdateImages(IEnumerable<int> images)
        {
            throw new System.NotImplementedException();
        }
    }
}
