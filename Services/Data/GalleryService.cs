using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Data.Models;
using Data.Repositories;
using Services.Mapping;
using Services.Data.Interfaces;

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

        public async Task CreateGallery(string galleryName, string description, bool isPrivate)
        {
            try
            {
                var gallery = new Gallery()
                {
                    Name = galleryName,
                    Description = description,
                    IsPrivate = isPrivate
                };
                await galleryRepository.AddAsync(gallery);
                await galleryRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: throw error and send email notification (add error handler middleware)
            }
        }

        public async Task<bool> EditGalleryForAdmin(string galleryId, string name, string description, bool isDeleted, bool isPrivate)
        {
            try
            {
                var res = await galleryRepository.All().FirstOrDefaultAsync(g => g.Id == galleryId);
                res.Name = name;
                res.Description = description;
                res.IsDeleted = isDeleted;
                res.DeletedOn = DateTime.UtcNow;
                res.IsPrivate = isPrivate;

                galleryRepository.Update(res);
                await galleryRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllGalleriesForAdmin<T>()
        {
            var res = await galleryRepository.All().To<T>().ToListAsync();
            return res;
        }

        public async Task<IEnumerable<T>> GetListOfAllProjectsForPublicGallery<T>(string galleryId)
        {
            var result = await this.projectRepository.All().Where(a => a.GalleryId == galleryId && a.Gallery.IsPrivate == false).OrderByDescending(x => x.Name).To<T>().ToListAsync();

            return result;
        }
    }
}
