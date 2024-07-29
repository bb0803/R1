using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.User
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
