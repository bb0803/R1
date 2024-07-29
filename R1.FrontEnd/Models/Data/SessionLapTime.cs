using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.Data
{
    public class SessionLapTime
    {
        [Required]
        public Int32 Id { get; set; }
        [MaxLength(20)]
        public string? SessionType { get; set; } = string.Empty;
        [Required]
        public Int32 SessionId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int16 Lap { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [MaxLength(50)]
        public string? Note { get; set; } = string.Empty;
        public Int32? TyreId { get; set; }
        public decimal? TyreStatus { get; set; }
        public decimal? Fuel { get; set; }
        public Byte? BrakePads { get; set; }
        public Int32? BrakeTemp { get; set; }
        public Byte? FrontDownforce { get; set; }
        public Byte? RearDownforce { get; set; }
        public Byte? BrakingMentailty { get; set; }
        public Byte? SpeedMentality { get; set; }
    }
}