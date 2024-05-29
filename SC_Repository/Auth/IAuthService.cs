using SC_Common.Dto;

namespace SC_Service.Auth
{
    public interface IAuthService
    {
        Task<ResponseDto> Register(UserDto userDto);
        Task<LoginResponseDto> Login (LoginDto loginDto);
        Task<CompanyValidationResponseDto> ValidateCompany(CompanyValidationDto companyValidationDto);
    }
}
