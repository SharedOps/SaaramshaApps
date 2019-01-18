using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaaramshaApps.Models.WebApi;

namespace SaaramshaApps.Interfaces
{
    public interface ISaaramshaTaskService
    {
        Task<int> AddTask(SaaramshaTask task);

        Task<IList<SaaramshaTask>> GetTasks();
    }
}
