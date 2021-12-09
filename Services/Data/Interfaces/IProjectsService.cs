using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<T>> GetAllProjectsForAdmin<T>();
        Task<T> GetProjectByIdForAdmin<T>(string projectId);
        Task MoveProjectToGalleryForAdmin(string galleryId ,string projectId);
    }
}
