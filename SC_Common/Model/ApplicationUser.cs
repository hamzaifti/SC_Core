using Microsoft.AspNetCore.Identity;

namespace SC_Common.Model
{

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public long CompanyId { get; set; }
    }
}
