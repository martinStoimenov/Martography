using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using Services.Mapping;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Images;
using Image = Data.Models.Image;

namespace Services.Data
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> imageRepository;

        private static readonly int ThumbnailWidth = 600;
        private static readonly int FullSizeWidth = 1800;

        public ImageService(IRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task InsertImage(string imageName, string projectId, bool showOnHomePage = false, bool isProjectThumbnail = false)
        {
            var image = new Image()
            {
                ProjectId = projectId,
                Name = imageName,
                ShowOnHomePageCarousel = showOnHomePage,
                IsProjectThumbnail = isProjectThumbnail
            };

            await imageRepository.AddAsync(image);
            await imageRepository.SaveChangesAsync();
        }

        public async Task SaveImagesToFileSystem(IEnumerable<ImageUploadViewModel> images)
        {
            try
            {
                foreach (var image in images)
                {
                    using var imageResult = await SixLabors.ImageSharp.Image.LoadAsync(image.Content);

                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        Common.GlobalConstants.BaseImagesFolder,
                        image.GalleryName,
                        image.ProjectName);

                    CheckIfGalleryAndProjectDirectoriesExist(image);

                    await SaveImage(imageResult, Path.Combine(path, image.Name), FullSizeWidth);
                    await SaveImage(imageResult, Path.Combine(path, $"{Common.GlobalConstants.ThumbnailPrefix}{image.Name}"), ThumbnailWidth);
                }
            }
            catch (System.Exception error)
            {
                var b = error.Message;
                var a = 0;
                throw;
            }
        }

        private async Task SaveImage(SixLabors.ImageSharp.Image image, string path, int resizeWidth)
        {
            var quality = 90;
            var width = image.Width;
            var height = image.Height;

            if (width > resizeWidth)
            {
                height = (int)((double)resizeWidth / width * height);
                width = resizeWidth;
                if(resizeWidth < FullSizeWidth)
                    quality = 75;
            }

            image.Mutate(i => i.Resize(width, height, KnownResamplers.Lanczos2));

            image.Metadata.ExifProfile = null;

            await image.SaveAsJpegAsync(path, new JpegEncoder() { Quality = quality });
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

        public async Task<string> UpdateImages(IEnumerable<ImagesInProjectUpdateModel> images)
        {
            var imagesFromDBtoUpdate = await imageRepository.All().Where(x => images.Select(i => i.Id).Contains(x.Id)).ToListAsync();

            foreach (var image in imagesFromDBtoUpdate)
            {
                if (images.Select(i => i.Id).Contains(image.Id))
                {
                    var changedImage = images.FirstOrDefault(x => x.Id == image.Id);

                    image.Position = changedImage.Position;
                    image.Description = changedImage.Description;
                    image.IsDeleted = changedImage.IsDeleted;
                    image.IsProjectThumbnail = changedImage.IsThumbnail;
                    image.ShowOnHomePageCarousel = changedImage.IsOnHomePageCarousel;
                    image.ShowOnHomePageGallery = changedImage.IsOnHomePageGallery;
                    image.DeletedOn = changedImage.IsDeleted ? DateTime.UtcNow : null;

                    imageRepository.Update(image);
                }
            }

            await imageRepository.SaveChangesAsync();

            return imagesFromDBtoUpdate.ElementAtOrDefault(0).ProjectId;
        }

        public async Task<IEnumerable<T>> GetAllHomePageImages<T>()
        {
            var allImages = await imageRepository.All().Where(i => i.ShowOnHomePageCarousel == true | i.ShowOnHomePageGallery == true).To<T>().ToListAsync();
            return allImages;
        }

        public async Task<IEnumerable<T>> GetRandomImagesForHomePageCards<T>()
        {
            try
            {
                var galleriesToDisplay = new string[] { "Portraits", "Nature", "Cars" };
                var images = new List<T>();

                foreach (var gallery in galleriesToDisplay)
                {
                    Random rand = new Random();
                    int toSkip = rand.Next(0, imageRepository.All().Where(i => i.Project.Gallery.Name == gallery).Count());

                    var image = await imageRepository.All()
                        .Where(i => i.Project.Gallery.Name == gallery)
                        .Skip(toSkip)
                        .Take(1)
                        .To<T>()
                        .FirstOrDefaultAsync();

                    if (image != null)
                        images.Add(image);
                }
                return images;
            }
            catch (Exception ex)
            {
                var a = 0;
                return new List<T>();
                //throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>() => await imageRepository.All().To<T>().ToListAsync();
    }
}
