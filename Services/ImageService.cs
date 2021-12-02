using Data.Models;
using Data.Repositories;
using Services.Data.Interfaces;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> imageRepository;

        public ImageService(IRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task InsertImage(string imageName, string projectId)
        {
            var image = new Image()
            {
                ProjectId = projectId,
                Url = imageName
            };

            await imageRepository.AddAsync(image);
            await imageRepository.SaveChangesAsync();
        }
    }
}
