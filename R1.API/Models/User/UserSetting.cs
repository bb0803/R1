using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.User
{
    public class UserSetting
    {
        [Required, EmailAddress, Key]
        public string Username { get; set; }
        public int CurrentWorldId { get; set; }
        public int CurrentTeamId { get; set; }
        public int? CurrentSessionId { get; set; }
    }
}
