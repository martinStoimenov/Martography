﻿using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using Services.Mapping;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data
{
    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectRepository;
        private readonly IGalleryService galleryService;

        public ProjectsService(IDeletableEntityRepository<Project> projectRepository, IGalleryService galleryService)
        {
            this.projectRepository = projectRepository;
            this.galleryService = galleryService;
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
            var proj = await projectRepository.All().Where(x => x.Id == projectId).Include(x => x.Gallery).FirstOrDefaultAsync();

            if (proj.Name.ToLower() != name.ToLower())
                RenameFolder(proj, name);

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
        public async Task<IEnumerable<T>> GetAllProjects<T>()
        {
            var res = await projectRepository.All().To<T>().ToListAsync();
            return res;
        }

        public async Task<T> GetProjectByIdForAdmin<T>(string projectId)
        {
            var res = await projectRepository.AllWithDeleted().Where(p => p.Id == projectId).To<T>().FirstOrDefaultAsync();
            return res;
        }

        public async Task MoveProjectToGalleryForAdmin(string galleryId, string projectId)
        {
            var project = await projectRepository.AllWithDeleted().Include(x => x.Gallery).FirstOrDefaultAsync(x => x.Id == projectId);

            if (project?.GalleryId != galleryId)
            {
                var newGallery = await galleryService.GetGallery<ViewModels.GalleryModels.SingleGalleryViewModel>(galleryId);

                if (MoveFolder(project, newGallery?.Name))
                {
                    project.GalleryId = galleryId;
                    projectRepository.Update(project);
                    await projectRepository.SaveChangesAsync();
                }
            }
        }

        public async Task UnDeleteProject(string projectId)
        {
            var proj = await projectRepository.AllWithDeleted().FirstOrDefaultAsync(x => x.Id == projectId);

            projectRepository.Undelete(proj);
            await projectRepository.SaveChangesAsync();
        }

        private void RenameFolder(Project project, string newName)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Common.GlobalConstants.BaseImagesFolder, project.Gallery.Name);
            var oldPath = Path.Combine(basePath, project.Name);
            var newPath = Path.Combine(basePath, newName);

            if (Directory.Exists(oldPath))
            {
                Directory.Move(oldPath, newPath);
            }
        }

        private bool MoveFolder(Project project, string galleryName)
        {
            bool isMoved = false;

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Common.GlobalConstants.BaseImagesFolder);
            var oldPath = Path.Combine(basePath, project.Gallery.Name, project.Name);
            var newPath = Path.Combine(basePath, galleryName, project.Name);

            if (Directory.Exists(oldPath))
            {
                Directory.Move(oldPath, newPath);
                isMoved = true;
            }
            return isMoved;
        }
    }
}
