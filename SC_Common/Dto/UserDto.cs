using Microsoft.AspNetCore.Identity;

namespace SC_Common.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long CompanyId { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
