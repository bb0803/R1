using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class Transaction
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 WorldId { get; set; }
        [Required]
        public Int32 ClassId { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public DateTime? When { get; set; }
        [MaxLength(100)]
        public string? Notes { get; set; } = string.Empty;
    }
}