using R1.FrontEnd.WA.Models.API;
using R1.FrontEnd.WA.Models.User;

namespace R1.FrontEnd.WA.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> LogoutAsync();
    }
}
