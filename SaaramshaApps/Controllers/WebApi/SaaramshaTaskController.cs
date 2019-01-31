using System.Collections.Generic;
using System.Web.Http;
using SaaramshaApps.Interfaces;
using System.Threading.Tasks;
using SaaramshaApps.Models.WebApi;
using System.Web.Http.Description;
using SaaramshaApps.Common;

namespace SaaramshaApps.Controllers.WebApi
{
    [RoutePrefix("api/saaramshaapp")]
    public class SaaramshaTaskController : ApiController
    {
        private readonly ISaaramshaTaskService _iSaaramshaTaskService;

        public SaaramshaTaskController(ISaaramshaTaskService iSaaramshaTaskService)
        {
            _iSaaramshaTaskService = iSaaramshaTaskService;
        }

        [HttpPost]
        [Route("addtask")]
        [ResponseType(typeof(SaaramshaTask))]
        public async Task<Response> AddTask([FromBody] SaaramshaTask task)
        {
            int result= await _iSaaramshaTaskService.AddTask(task);
            return ResponseUtility.CreateResponse(result);
        }

        [HttpGet]
        [Route("gettasks")]
        [ResponseType(typeof(SaaramshaTask))]
        public async Task<Response> GetTasks()
        {
            IList<SaaramshaTask> result = await _iSaaramshaTaskService.GetTasks();
            return ResponseUtility.CreateResponse(result);
        }
    }
}
