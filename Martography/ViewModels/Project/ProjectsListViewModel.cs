using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martography.ViewModels.Project
{
    public class ProjectsListViewModel
    {
        public IEnumerable<SingleProjectViewModel> Projects { get; set; }
    }
}
