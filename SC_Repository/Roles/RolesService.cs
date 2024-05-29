using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SC_Service.Roles
{
    public class RolesService : IRolesService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}
