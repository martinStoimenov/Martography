using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class GalleryService : IGalleryService
    {
        private readonly IRepository<Gallery> galleryRepository;
        private readonly IRepository<Project> projectRepository;

        public GalleryService(IRepository<Gallery> galleryRepository, IRepository<Project> projectRepository)
        {
            this.galleryRepository = galleryRepository;
            this.projectRepository = projectRepository;
        }

        public async Task<bool> CreateGallery(string galleryName, string description, bool isPrivate)
        {
            try
            {
                var gallery = new Gallery()
                {
                    Name = galleryName,
                    Description = description,
                    IsPrivate = isPrivate
                };
                galleryRepository.Update(gallery);
                await galleryRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllForPublicGallery<T>(string galleryId)
        {
            var result = await this.projectRepository.All().Where(a => a.GalleryId == galleryId && a.Gallery.IsPrivate == false).OrderByDescending(x=>x.Name).To<T>().ToListAsync();

            return result;
        }
    }
}
