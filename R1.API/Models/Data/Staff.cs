using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class Staff
    {
        [Required]
        public Int32 Id { get; set; }
        [MaxLength(100)]
        public string? StaffName { get; set; } = string.Empty;
        [Required]
        public Int32 TeamId { get; set; }
        [Required]
        public Int32 X_StaffId { get; set; }
        [MaxLength(50)]
        public string? StaffType { get; set; } = string.Empty;
        public Int16? Season { get; set; }
        public decimal? Salary { get; set; }
        public Byte? Rating { get; set; }
    }
}
