using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.Web.Models.Data
{
    public class Gearboxes
    {
        [Required]
        public Int32 Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? Type { get; set; } = string.Empty;
        public Int32? TeamId { get; set; }
        public decimal? Status { get; set; }
        public decimal? LowSpeedFactor { get; set; }
        public decimal? MidSpeedFactor { get; set; }
        public decimal? HighSpeedFactor { get; set; }
    }
}