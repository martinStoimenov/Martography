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
    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectRepository;

        public ProjectsService(IDeletableEntityRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task CreateProject(string name, string descriptiom, string galleryId)
        {
            var proj = new Project()
            {
                GalleryId = galleryId,
                Name = name,
                Description = descriptiom
            };

            await projectRepository.AddAsync(proj);
            await projectRepository.SaveChangesAsync();
        }

        public async Task DeleteProject(string projectId)
        {
            var proj = await projectRepository.All().FirstOrDefaultAsync(x => x.Id == projectId);

            projectRepository.Delete(proj);
            await projectRepository.SaveChangesAsync();
        }

        public async Task Edit(string projectId, string name, string description, bool isDeleted)
        {
            var proj = await projectRepository.All().FirstOrDefaultAsync(x => x.Id == projectId);

            proj.Name = name;
            proj.Description = description;

            projectRepository.Update(proj);

            if (isDeleted == true)
                projectRepository.Delete(proj);

            await projectRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllProjectsForAdmin<T>()
        {
            var res = await projectRepository.AllWithDeleted().To<T>().ToListAsync();
            return res;
        }

        public async Task<T> GetProjectByIdForAdmin<T>(string projectId)
        {
            var res = await projectRepository.AllWithDeleted().Where(p => p.Id == projectId).To<T>().FirstOrDefaultAsync();
            return res;
        }

        public async Task MoveProjectToGalleryForAdmin(string galleryId, string projectId)
        {
            var project = await projectRepository.AllWithDeleted().FirstOrDefaultAsync(x => x.Id == projectId);

            if (project.GalleryId != galleryId)
            {
                project.GalleryId = galleryId;
                projectRepository.Update(project);
                await projectRepository.SaveChangesAsync();
            }
        }

        public async Task UnDeleteProject(string projectId)
        {
            var proj = await projectRepository.AllWithDeleted().FirstOrDefaultAsync(x => x.Id == projectId);

            projectRepository.Undelete(proj);
            await projectRepository.SaveChangesAsync();
        }
    }
}
