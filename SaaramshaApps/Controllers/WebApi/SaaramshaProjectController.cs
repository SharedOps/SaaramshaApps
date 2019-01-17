using System.Web.Http;
using SaaramshaApps.Models.WebApi;
using SaaramshaApps.Interfaces;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Collections.Generic;

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
        public async Task<int> AddProject([FromBody] SaaramshaProject project)
        {
            return await _iSaaramashaProjectService.AddProject(project);
        }

        [HttpGet]
        [Route("getprojects")]
        [ResponseType(typeof(SaaramshaProject))]
        public async Task<IList<SaaramshaProject>> GetProjects()
        {
            return await _iSaaramashaProjectService.GetProjects();
        }
    }
}
