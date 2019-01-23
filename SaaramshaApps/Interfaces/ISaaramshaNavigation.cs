using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaaramshaApps.Interfaces;
using SaaramshaApps.Models.WebApi;
namespace SaaramshaApps.Interfaces
{
    public interface ISaaramshaNavigation
    {

        Task<int> AddNavigationItem(SaaramshaNavigation navItem);

        Task<IList<SaaramshaNavigation>> GetNavigationLinks();

        Task<IList<SaaramshaNavigation>> GetNavigationLinksByStatus(bool isActive);
    }
}
