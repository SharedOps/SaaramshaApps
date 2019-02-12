using SaaramshaApps.Common;
using SaaramshaApps.Interfaces;
using SaaramshaApps.Models.WebApi;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SaaramshaApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISaaramshaUserService _iSaaramshaUserService;

        public HomeController(ISaaramshaUserService SaaramshaUserService)
        {
            _iSaaramshaUserService = SaaramshaUserService;
        }

        public ActionResult Index()
        {
            var result = GetUsers();

            return View(result.Result);
        }

        public async Task<IList<SaaramshaUser>> GetUsers()
        {
            return await _iSaaramshaUserService.GetUsers();
        }


    }
}
