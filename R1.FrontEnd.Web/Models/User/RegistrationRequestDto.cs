namespace R1.FrontEnd.Web.Models.User
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
