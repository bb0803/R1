using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class PracticeLapTime
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 PracticeId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        public Int16? Lap { get; set; }
        public TimeSpan? Time { get; set; }
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