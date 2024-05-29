using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SC_Common.Model;
using SC_Service.User;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SC_Service.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public JwtMiddleware(RequestDelegate next,
                             IConfiguration configuration,
                             IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var allowedUrls = new string[] { "/api/Auth/Login", "/api/Auth/Login" };

                var requestUrl = context.Request.Path;

                if (!allowedUrls.Any(x => x == requestUrl.Value))
                {

                    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                    if (token != null)
                    {
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                            await AttachUserToContext(context, token, userService);
                        }
                    }
                }

                await _next(context);

            }
            catch(SecurityTokenExpiredException ex)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized!. You are not supposed to access this");
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized!. You are not supposed to access this");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task AttachUserToContext(HttpContext context, string token, IUserService userService)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                UserContext.User = await userService.GetUserById(userId);
                UserContext.Roles = await userService.GetUserRoles(UserContext.User);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
