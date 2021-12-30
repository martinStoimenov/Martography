using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data
{
    public class BlogService : IBlogService
    {
        private readonly IDeletableEntityRepository<BlogPost> deletableBlogRepository;

        public BlogService(IDeletableEntityRepository<BlogPost> deletableBlogRepository)
        {
            this.deletableBlogRepository = deletableBlogRepository;
        }

        public async Task<string> CreatePost(string htmlContent, string title, string author, string galleryId, string imageId)
        {
            var post = new BlogPost()
            {
                Content = htmlContent,
                Title = title,
                GalleryId = galleryId,
                ImageId = imageId,
                Author = author
            };

            await deletableBlogRepository.AddAsync(post);
            await deletableBlogRepository.SaveChangesAsync();
            
            return post.Id;
        }

        public async Task<string> EditPost(string id, string htmlContent, string title, string author, string galleryId, string imageId)
        {
            var post = await deletableBlogRepository.AllWithDeleted().FirstOrDefaultAsync(x => x.Id == id);

            if (post == null)
                return "Not Found";

            post.Content = htmlContent;
            post.Title = title;
            post.GalleryId = galleryId;
            post.ImageId = imageId;
            post.Author = author;

            deletableBlogRepository.Update(post);
            await deletableBlogRepository.SaveChangesAsync();

            return post.Id;
        }

        public async Task<IEnumerable<T>> GetAll<T>() => await deletableBlogRepository.All().To<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllPostsWithDeletedForAdmin<T>()
        {
            var res = await deletableBlogRepository.AllWithDeleted().To<T>().ToListAsync();
            return res;
        }

        public async Task<T> GetPost<T>(string id) => await deletableBlogRepository.AllWithDeleted().Where(x => x.Id == id).To<T>().FirstOrDefaultAsync();
    }
}
