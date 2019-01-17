using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaaramshaApps.Interfaces;
using SaaramshaApps.Models.WebApi;

namespace SaaramshaApps.Interfaces
{
    public interface ISaaramshaProjectService
    {

        Task<int> AddProject(SaaramshaProject project);

        Task<IList<SaaramshaProject>> GetProjects();
    }
}
