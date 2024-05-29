using Microsoft.AspNetCore.Identity;
using SC_Common.Model;

namespace SC_Service.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        public async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            if (user == null || user.Id == null)
            {
                user = UserContext.User;
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList();
        }

        public async Task<bool> CheckBankPermission()
        {
            ApplicationUser user = UserContext.User;

            if(user == null)
            {
                return false;
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            return userRoles.Any(x => x == "Bank");

        }

    }
}
