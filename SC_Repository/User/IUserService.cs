using SC_Common.Model;

namespace SC_Service.User
{
    public interface IUserService
    {
        Task<bool> CheckBankPermission();
        Task<ApplicationUser> GetUserById(string id);
        Task<List<string>> GetUserRoles(ApplicationUser user);
    }
}
