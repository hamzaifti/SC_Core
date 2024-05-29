using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SC_Common.Model;
using SC_Service.User;

namespace SC_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRoles()
        {
           return Ok(await _userService.GetUserRoles(UserContext.User));
        }

        [HttpGet]
        public async Task<IActionResult> CheckBankPermission()
        {
            return Ok(await _userService.CheckBankPermission());
        }
    }
}
