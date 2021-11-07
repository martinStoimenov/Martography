using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Data.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<T>> GetAllProjectsForAdmin<T>();
    }
}
