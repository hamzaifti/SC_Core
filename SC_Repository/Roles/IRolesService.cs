using Microsoft.AspNetCore.Identity;

namespace SC_Service.Roles
{
    public interface IRolesService
    {
        Task<IEnumerable<IdentityRole>> GetAllRoles();
    }
}
