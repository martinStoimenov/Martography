using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data.Interfaces
{
    public interface IGalleryService
    {
        IEnumerable<Gallery> GetAllGalleriesCached();
        Task<T> GetGallery<T>(string id);
        Task CreateGallery(string galleryName, string description, bool isPrivate);
        Task<IEnumerable<T>> GetAllGalleriesForAdmin<T>();
        Task<bool> EditGalleryForAdmin(string galleryId, string name, string description, bool isDeleted, bool isPrivate);
    }
}
