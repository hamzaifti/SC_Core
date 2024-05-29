using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SC_Common.Dto;
using SC_Common.Model;
using SC_DBContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SC_Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           ApplicationDBContext context,
                           IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }

        public async Task<ResponseDto> Register(UserDto userDto)
        {
            try
            {
                ApplicationUser user = new()
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    UserName = userDto.Email,
                    CompanyId = userDto.CompanyId,
                };

                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    foreach (var role in userDto.Roles)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    return new ResponseDto { Success = true, Message = "User Registered" };
                }
                else
                {
                    return new ResponseDto
                    {
                        Success = false,
                        Message = string.Join(",", result.Errors.Select(x => x.Description))
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<CompanyValidationResponseDto> ValidateCompany(CompanyValidationDto companyValidationDto)
        {
            try
            {
                Company? company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyKey == companyValidationDto.CompanyKey);

                if(company != null && company.Id > 0)
                {
                    return new CompanyValidationResponseDto
                    {
                        Success = true,
                        Message = "Validated",
                        CompanyId = company.Id
                    };
                }
                else
                {
                    return new CompanyValidationResponseDto
                    {
                        Success = false,
                        Message = "Company Not Registered",
                        CompanyId = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return new CompanyValidationResponseDto
                {
                    Success = false,
                    Message = ex.Message,
                    CompanyId = 0
                };
            }
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    return new LoginResponseDto { Success = false, Message = "User is not registered" };
                }

                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, isPersistent: loginDto.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //making claim list which is a set of data stored in jwt on which basis it authenticates and authorizes
                    List<Claim> authClaimList = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //unique id for tracking and uniqueness of JWT
                    };


                    //adding roles in the claim
                    var roles = await _userManager.GetRolesAsync(user);

                    authClaimList.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));


                    JwtSecurityToken token = GetToken(authClaimList);

                    return new LoginResponseDto { Success = true, Message = "Login successful", Token = new JwtSecurityTokenHandler().WriteToken(token), User = user, Roles = roles.ToList() };
                }
                else
                {
                    return new LoginResponseDto { Success = false, Message = "Invalid credentials" };
                }
            }
            catch (Exception ex)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
