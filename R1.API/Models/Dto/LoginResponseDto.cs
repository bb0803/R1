using R1.Services.API.Models.User;

namespace R1.Services.API.Models.DTO
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
