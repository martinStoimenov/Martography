using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Testimonials;

namespace Services.Data.Interfaces
{
    public interface ITestimonialService
    {
        Task Create(string name, string company, string jobTitle, string emailAddress, string content);
        Task<IEnumerable<T>> GetAllApproved<T>();
        Task<IEnumerable<T>> GetAllForAdmin<T>();
        Task EditForAdmin(List<TestimonialsAdminModel> model);
    }
}
