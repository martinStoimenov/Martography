using Data;
using Data.Models;
using Data.Repositories;
using Martography.Areas.Administration.ViewModels;
using Microsoft.EntityFrameworkCore;
using Services.Data;
using Services.Mapping;
using System.Reflection;
using ViewModels;
using ViewModels.Images;

namespace Martography.Tests
{
    public class ImageServiceTests
    {
        public ImageServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, typeof(Startup).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetAllImages_ReturnsCorrect_CountOfImages()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfRepository<Image>(new ApplicationDbContext(options.Options));

            var service = new ImageService(repository);

            await service.SaveImages(GetImagesList(), "1");

            var imagelist = await service.GetAll<AdminImageDropdownViewModel>();

            Assert.Equal(3, imagelist.Count());
        }

        private IEnumerable<ImageUploadViewModel> GetImagesList()
        {
            var path = @"../../../../Martography/wwwroot/style/images/dummy.png";

            if (File.Exists(path) == false)
                throw new DirectoryNotFoundException();

            var list = new List<ImageUploadViewModel>() {
                new ImageUploadViewModel { Content = new FileStream(path, FileMode.Open, FileAccess.Read),Name = "TestName", GalleryName = "Test", ProjectName = "Project Test" },
                new ImageUploadViewModel { Content = new FileStream(path, FileMode.Open, FileAccess.Read),Name = "TestName", GalleryName = "Test1", ProjectName = "Project Test" },
                new ImageUploadViewModel { Content = new FileStream(path, FileMode.Open, FileAccess.Read),Name = "TestName", GalleryName = "Test2", ProjectName = "Project Test" } 
            };
            return list;
        }
    }
}
