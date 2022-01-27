using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IRepository<Testimonials> repository;

        public TestimonialService(IRepository<Testimonials> repository)
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

        public async Task<IEnumerable<T>> GetAllApproved<T>()
            => await repository.All().Where(
                x => x.IsDeleted == false &&
                x.IsApproved == true &&
                x.IsVisible == true)
            .To<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllForAdmin<T>()
            => await repository.All().To<T>().ToListAsync();
    }
}
