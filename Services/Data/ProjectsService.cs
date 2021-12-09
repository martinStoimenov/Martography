using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectRepository;

        public ProjectsService(IDeletableEntityRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public async Task<IEnumerable<T>> GetAllProjectsForAdmin<T>()
        {
            var res = await projectRepository.All().To<T>().ToListAsync();
            return res;
        }

        public async Task<T> GetProjectByIdForAdmin<T>(string projectId)
        {
            var res = await projectRepository.All().Where(p => p.Id == projectId).To<T>().FirstOrDefaultAsync();
            return res;
        }

        public async Task MoveProjectToGalleryForAdmin(string galleryId, string projectId)
        {
            var project = await projectRepository.All().FirstOrDefaultAsync(x => x.Id == projectId);

            if (project.GalleryId != galleryId)
            {
                project.GalleryId = galleryId;
                projectRepository.Update(project);
                await projectRepository.SaveChangesAsync();
            }
        }
    }
}
