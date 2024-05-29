using Microsoft.AspNetCore.Identity;

namespace SC_Common.Model
{
    public static class UserContext
    {
        public static ApplicationUser User { get; set; }
        public static List<string> Roles { get; set; }
    }
}
