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
    public class SaaramshaUserController : ApiController
    {
        private readonly ISaaramshaUserService _iSaaramshaUserService;

        public SaaramshaUserController(ISaaramshaUserService SaaramshaUserService)
        {
            _iSaaramshaUserService = SaaramshaUserService;
        }

        [HttpPost]
        [Route("adduser")]
        [ResponseType(typeof(SaaramshaUser))]
        public async Task<Response> AddUser([FromBody] SaaramshaUser user)
        {
            int result= await _iSaaramshaUserService.AddUser(user);
            return ResponseUtility.CreateResponse(result);
        }

        [HttpGet]
        [Route("getusers")]
        [ResponseType(typeof(SaaramshaUser))]
        public async Task<Response> GetUsers()
        {
            IList<SaaramshaUser> result = await _iSaaramshaUserService.GetUsers();
            return ResponseUtility.CreateResponse(result);
    
        }
      
    }
}
