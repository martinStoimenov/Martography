using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data.Interfaces
{
    public interface IBlogService
    {
        Task<string> CreatePost(string htmlContent, string title, string author, string galleryId, string imageId);
        Task<string> EditPost(string id, string htmlContent, string title, string author, string galleryId ,string imageId);
        Task<T> GetPost<T>(string id);
        Task<IEnumerable<T>> GetAllPostsWithDeletedForAdmin<T>();
        Task<IEnumerable<T>> GetAll<T>();
    }
}
