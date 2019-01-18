using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SaaramshaApps.Interfaces;
using Dapper;
using Autofac;
using System.Threading.Tasks;
using SaaramshaApps.Models.WebApi;
using System.Web.Http.Description;

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
        public async Task<int> AddTask([FromBody] SaaramshaTask task)
        {
            return await _iSaaramshaTaskService.AddTask(task);
        }

        [HttpGet]
        [Route("gettasks")]
        [ResponseType(typeof(SaaramshaTask))]
        public async Task<IList<SaaramshaTask>> GetTasks()
        {
            return await _iSaaramshaTaskService.GetTasks();
        }
    }
}
