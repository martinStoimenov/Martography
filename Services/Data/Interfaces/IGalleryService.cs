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
        Task<IEnumerable<T>> GetAllForPublicGallery<T>(string galleryId);
        Task<bool> CreateGallery(string galleryName, string description, bool isPrivate);
    }
}
