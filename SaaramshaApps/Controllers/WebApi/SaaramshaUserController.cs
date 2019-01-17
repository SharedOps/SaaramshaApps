using System.Web.Http;
using SaaramshaApps.Models.WebApi;
using SaaramshaApps.Interfaces;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Collections.Generic;

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
        public async Task<int> AddUser([FromBody] SaaramshaUser user)
        {
            return await _iSaaramshaUserService.AddUser(user);
        }

        [HttpGet]
        [Route("getusers")]
        [ResponseType(typeof(SaaramshaUser))]
        public async Task<IList<SaaramshaUser>> GetUsers()
        {
            return await _iSaaramshaUserService.GetUsers();
        }
    }
}
