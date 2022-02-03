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
        private readonly IDeletableEntityRepository<Testimonials> repository;

        public TestimonialService(IDeletableEntityRepository<Testimonials> repository)
        {
            this.repository = repository;
        }
        public async Task Create(string name, string company, string jobTitle, string emailAddress, string content)
        {
            var testimonial = new Testimonials()
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

        public async Task EditForAdmin(List<TestimonialsAdminModel> model)
        {
            var testimonials = await repository.AllWithDeleted().Where(x=> model.Select(model=>model.Id).Contains(x.Id)).ToListAsync();

            foreach (var item in testimonials)
            {
                item.IsApproved = model.FirstOrDefault(x=>x.Id == item.Id).IsApproved;
                item.IsVisible = model.FirstOrDefault(x=>x.Id == item.Id).IsVisible;
                repository.Update(item);
            }
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllApproved<T>()
            => await repository.All().Where(
                x => x.IsDeleted == false &&
                x.IsApproved == true &&
                x.IsVisible == true)
            .To<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllForAdmin<T>()
            => await repository.AllWithDeleted().To<T>().ToListAsync();
    }
}
