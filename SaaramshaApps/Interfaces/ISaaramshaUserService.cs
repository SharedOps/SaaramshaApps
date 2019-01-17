using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaaramshaApps.Models.WebApi;

namespace SaaramshaApps.Interfaces
{
   public interface ISaaramshaUserService
    {
        Task<int> AddUser(SaaramshaUser user);

        Task<IList<SaaramshaUser>> GetUsers();

    }
}
