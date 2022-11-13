using Data;
using Data.Models;
using Data.Repositories;
using Martography.Areas.Administration.ViewModels;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Moq;
using Services.Data;
using Services.Mapping;
using System.Reflection;
using System.Text;
using ViewModels;
using ViewModels.Images;

namespace Martography.Tests
{
    public class ImageServiceTests
    {
        //public ImageServiceTests()
        //{
        //    AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, typeof(Startup).GetTypeInfo().Assembly);
        //}

        //[Fact]
        //public async Task Method_ReturnsCorrect_CountOfImages()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

        //    //var repository = new Mock<IRepository<Image>>();
        //    //repository.Setup(r => r.AllAsNoTracking()).Returns(new List<Image>
        //    //{
        //    //                                                new Image(),
        //    //                                                new Image(),
        //    //                                                new Image(),
        //    //                                            }.AsQueryable());
          
        //    var repository = new EfRepository<Image>(new ApplicationDbContext(options.Options));

        //    var service = new ImageService(repository);

        //    await service.SaveImages(GetImagesList(), "1");

        //    var imagelist = await service.GetAll<AdminImageDropdownViewModel>();

        //    Assert.Equal(3, imagelist.Count());
        //}

        //private IEnumerable<ImageUploadViewModel> GetImagesList()
        //{
        //    var list = new List<ImageUploadViewModel>() {
        //        new ImageUploadViewModel { Content = new MemoryStream(Encoding.UTF8.GetBytes("whatever")) }, 
        //        new ImageUploadViewModel { Content = new MemoryStream(Encoding.UTF8.GetBytes("whatever")) }, 
        //        new ImageUploadViewModel { Content = new MemoryStream(Encoding.UTF8.GetBytes("whatever")) }, 
        //    };
        //    return list;
        //}
    }
}
