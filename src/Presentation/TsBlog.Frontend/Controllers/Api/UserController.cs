using System.Web.Http;
using TsBlog.Services;

namespace TsBlog.Frontend.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IHttpActionResult GetUserList()
        {
            var users = _userService.FindAll();
            return Ok(users);
        }
    }
}
