using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProjectModels
{
    public class ProjectModel
    {
        public SingleProjectViewModel singleProject { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
