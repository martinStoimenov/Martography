using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data.Interfaces
{
    public interface IImageService
    {
        Task InsertImage(string imageName, string projectId);
    }
}
