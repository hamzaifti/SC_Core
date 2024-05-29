using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SC_Common.Dto;
using SC_Service.Auth;


namespace SC_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            return Ok(await _authService.Register(userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return Ok(await _authService.Login(loginDto));
        }

        [HttpPost]
        public async Task<IActionResult> ValidateCompany(CompanyValidationDto companyValidationDto)
        {
            return Ok(await _authService.ValidateCompany(companyValidationDto));
        }


    }
}
