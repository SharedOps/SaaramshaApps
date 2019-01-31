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
    public class SaaramshaProjectController : ApiController
    {
        private readonly ISaaramshaProjectService _iSaaramashaProjectService;

        public SaaramshaProjectController(ISaaramshaProjectService SaaramshaProjectService)
        {
            _iSaaramashaProjectService = SaaramshaProjectService;
        }

        [HttpPost]
        [Route("addproject")]
        [ResponseType(typeof(SaaramshaProject))]
        public async Task<Response> AddProject([FromBody] SaaramshaProject project)
        {
            int result = await _iSaaramashaProjectService.AddProject(project);
            return ResponseUtility.CreateResponse(result);
        }

        [HttpGet]
        [Route("getprojects")]
        [ResponseType(typeof(SaaramshaProject))]
        public async Task<Response> GetProjects()
        {
            IList<SaaramshaProject> result = await _iSaaramashaProjectService.GetProjects();
            return ResponseUtility.CreateResponse(result);
  ;
        }
    }
}
