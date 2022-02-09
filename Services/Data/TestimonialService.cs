using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Testimonials;

namespace Services.Data
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IDeletableEntityRepository<Testimonial> repository;

        public TestimonialService(IDeletableEntityRepository<Testimonial> repository)
        {
            this.repository = repository;
        }
        public async Task Create(string name, string company, string jobTitle, string emailAddress, string content)
        {
            var testimonial = new Testimonial()
            {
                Company = company,
                Content = content,
                EmailAddress = emailAddress,
                PersonName = name,
                Position = jobTitle
            };
            await repository.AddAsync(testimonial);
            await repository.SaveChangesAsync();
        }

        public async Task EditForAdmin(string Id, bool isVisible, bool isApproved, bool isDeleted, string imageId)
        {
            var databaseTestimonial = await repository.AllWithDeleted().FirstOrDefaultAsync(x => x.Id == Id);

            databaseTestimonial.ImageId = imageId;
            databaseTestimonial.IsVisible = isVisible;
            databaseTestimonial.IsApproved = isApproved;
            databaseTestimonial.IsDeleted = isDeleted;

            repository.Update(databaseTestimonial);

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllApproved<T>()
            => await repository.All().Where(
                x => x.IsDeleted == false &&
                x.IsApproved == true ||
                x.IsVisible == true)
            .To<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllForAdmin<T>()
            => await repository.AllWithDeleted().To<T>().ToListAsync();
    }
}
