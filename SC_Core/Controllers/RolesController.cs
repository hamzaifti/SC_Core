using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SC_Common.Model;
using SC_Service.Roles;

namespace SC_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _rolesService.GetAllRoles());
        }
    }
}
