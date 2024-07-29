using Microsoft.AspNetCore.Identity;

namespace R1.Services.API.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
