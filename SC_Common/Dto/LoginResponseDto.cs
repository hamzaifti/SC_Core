using Microsoft.AspNetCore.Identity;
using SC_Common.Model;

namespace SC_Common.Dto
{
    public class LoginResponseDto:ResponseDto
    {
        public string Token { get; set; }
        public ApplicationUser User { get; set; }
        public List<string> Roles { get; set; }
    }
}
