using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Data
{
    public class UserCustom
    {
        [Required, EmailAddress, Key]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public int TenantId { get; set; }
    }
}
