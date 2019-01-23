using System.Web.Http;
using SaaramshaApps.Models.WebApi;
using SaaramshaApps.Interfaces;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Collections.Generic;
using SaaramshaApps.Common;

namespace SaaramshaApps.Controllers.WebApi
{

    [RoutePrefix("api/saaramshaapp")]
    public class SaaramshaNavigationController : ApiController
    {
        private readonly ISaaramshaNavigation _iSaaramshaNavigation;

        public SaaramshaNavigationController(ISaaramshaNavigation SaaramshaNavigationService)
        {
            _iSaaramshaNavigation = SaaramshaNavigationService;
        }

        [HttpPost]
        [Route("addnavigationlink")]
        [ResponseType(typeof(SaaramshaNavigation))]
        public async Task<Response> AddUser([FromBody] SaaramshaNavigation item)
        {
            int result = await _iSaaramshaNavigation.AddNavigationItem(item);
            return ResponseUtility.CreateResponse(result);
        }

        [HttpGet]
        [Route("getnavigationlinks")]
        [ResponseType(typeof(SaaramshaNavigation))]
        public async Task<Response> GetNavigationLinks()
        {

            IList<SaaramshaNavigation> result = await _iSaaramshaNavigation.GetNavigationLinks();
            return ResponseUtility.CreateResponse(result);
        }


        [HttpGet]
        [Route("getnavigationlinksbystatus")]
        [ResponseType(typeof(SaaramshaNavigation))]
        public async Task<Response> GetNavigationLinksByStatus(bool isActive)
        {
            IList<SaaramshaNavigation> result = await _iSaaramshaNavigation.GetNavigationLinksByStatus(isActive);
            return ResponseUtility.CreateResponse(result);
        }
    }
}
