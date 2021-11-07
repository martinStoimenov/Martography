using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Seeding
{
    public class InitialMartographyData : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!await dbContext.Galleries.AnyAsync())
            {
                var dictGalleries = new Dictionary<string, string>();
                dictGalleries.Add("Portraits", "");
                dictGalleries.Add("Cars", "");
                dictGalleries.Add("Nature", "");

                var galleries = dictGalleries.Select(x=> new Gallery() { Name = x.Key, Description = x.Value });
                await dbContext.Galleries.AddRangeAsync(galleries);
                await dbContext.SaveChangesAsync();
            }

            if (!await dbContext.Projects.AnyAsync())
            {
                var dictProjects = new Dictionary<string, string>();
                dictProjects.Add("Veronika", "");
                dictProjects.Add("South park", "");
                dictProjects.Add("Golf 4", "");
                dictProjects.Add("Nature adventures", "");

                var allGalleries = await dbContext.Galleries.ToListAsync();

                foreach (var gallery in allGalleries)
                {
                    if(gallery.Name == "Portraits")
                    {
                        var proj = new Project()
                        {
                            GalleryId = gallery.Id,
                            Name = dictProjects.Keys.Where(x => x == "Veronika").FirstOrDefault(),
                            Description = dictProjects.Where(x => x.Key == "Veronika").Select(x=>x.Value).FirstOrDefault()
                        };
                        var proj2 = new Project()
                        {
                            GalleryId = gallery.Id,
                            Name = dictProjects.Keys.Where(x => x == "South park").FirstOrDefault(),
                            Description = dictProjects.Where(x => x.Key == "South park").Select(x=>x.Value).FirstOrDefault()
                        };
                        await dbContext.Projects.AddAsync(proj);
                        await dbContext.Projects.AddAsync(proj2);
                    }
                    if(gallery.Name == "Cars")
                    {
                        var proj = new Project()
                        {
                            GalleryId = gallery.Id,
                            Name = dictProjects.Keys.Where(x => x == "Golf 4").FirstOrDefault(),
                            Description = dictProjects.Where(x => x.Key == "Golf 4").Select(x=>x.Value).FirstOrDefault()
                        };
                        await dbContext.Projects.AddAsync(proj);
                    }
                    if(gallery.Name == "Nature")
                    {
                        var proj = new Project()
                        {
                            GalleryId = gallery.Id,
                            Name = dictProjects.Keys.Where(x => x == "Nature adventures").FirstOrDefault(),
                            Description = dictProjects.Where(x => x.Key == "Nature adventures").Select(x => x.Value).FirstOrDefault()
                        };
                        await dbContext.Projects.AddAsync(proj);
                    }

                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
