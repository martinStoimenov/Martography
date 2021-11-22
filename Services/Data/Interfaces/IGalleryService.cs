using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data.Interfaces
{
    public interface IGalleryService
    {
        Task<IEnumerable<T>> GetListOfAllProjectsForPublicGallery<T>(string galleryId);
        Task<bool> CreateGallery(string galleryName, string description, bool isPrivate);
        Task<IEnumerable<T>> GetAllGalleriesForAdmin<T>();
        Task<bool> EditGalleryForAdmin(string galleryId, string name, string description, bool isDeleted, bool isPrivate);
    }
}
