using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.Data
{
    public class SessionStatus
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
        public Byte SpeedAbility { get; set; }
        public Byte? Consistency { get; set; }
        public Byte? BrakingAbility { get; set; }
        public Byte? Cornering { get; set; }
        public Byte? Overtaking { get; set; }
        public Byte? Defending { get; set; }
        public Byte? Aero { get; set; }
        public Byte? CarBrakes { get; set; }
        public Byte? Steering { get; set; }
        [Required]
        public Int32 Lap { get; set; }
        public Byte? Segment { get; set; }
        public decimal? Metres { get; set; }
        public Byte? Position { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public TimeSpan? LapTime { get; set; }
        [Required]
        public decimal CurrentSpeed { get; set; }
        public Int32? TyreId { get; set; }
        [Required]
        public decimal TyreStatus { get; set; }
        public decimal? Fuel { get; set; }
        [Required]
        public Byte BrakePads { get; set; }
        [Required]
        public Int32 BrakeTemp { get; set; }
        [Required]
        public Byte FrontDownforce { get; set; }
        [Required]
        public Byte RearDownforce { get; set; }
        public Byte? BrakingMentailty { get; set; }
        public Byte? SpeedMentality { get; set; }
        public decimal? TyreSpeedFactor { get; set; }
        public decimal? TyreDegradationFactor { get; set; }
    }
}