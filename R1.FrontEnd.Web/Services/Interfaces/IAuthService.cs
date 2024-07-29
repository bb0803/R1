using R1.FrontEnd.Web.Models.API;
using R1.FrontEnd.Web.Models.User;

namespace R1.FrontEnd.Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> LogoutAsync();
    }
}
