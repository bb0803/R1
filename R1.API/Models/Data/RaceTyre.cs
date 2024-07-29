using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class RaceTyre
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string CompundName { get; set; }
        [Required]
        public Int32 RaceId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public decimal SpeedFactor { get; set; }
        [Required]
        public decimal DegradationFactor { get; set; }
    }
}