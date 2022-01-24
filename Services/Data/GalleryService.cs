using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Data.Models;
using Data.Repositories;
using Services.Mapping;
using Services.Data.Interfaces;
using Z.EntityFramework.Plus;
using Microsoft.Extensions.Caching.Memory;
using System.IO;

namespace Services.Data
{
    public class GalleryService : IGalleryService
    {
        private readonly IDeletableEntityRepository<Gallery> galleryRepository;
        private readonly IRepository<Project> projectRepository;

        public GalleryService(IDeletableEntityRepository<Gallery> galleryRepository, IRepository<Project> projectRepository)
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

                if (res.Name.ToLower() != name.ToLower())
                    ChangeGalleryFolderName(res, name);

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
            var res = await galleryRepository.AllWithDeleted().To<T>().ToListAsync();
            return res;
        }

        public IEnumerable<T> GetAllGalleriesCached<T>()
            where T : class
        {
            try
            {

            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromDays(7) };
            QueryCacheManager.DefaultMemoryCacheEntryOptions = options;

            var result = galleryRepository.All().To<T>().FromCache().ToList();

            return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<T> GetGallery<T>(string id)
        {
            var gallery = await galleryRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefaultAsync();
            return gallery;
        }

        private void ChangeGalleryFolderName(Gallery gallery, string newName)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Common.GlobalConstants.BaseImagesFolder);
            var oldPath = Path.Combine(basePath, gallery.Name);
            var newPath = Path.Combine(basePath, newName);

            Directory.Move(oldPath, newPath);
        }
    }
}
