using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.Web.Models.Data
{
    public class RaceSplit
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 RaceId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int16 Lap { get; set; }
        [Required]
        public Byte SegmentNo { get; set; }
        [Required]
        public decimal SplitTime { get; set; }
        public decimal? BrakeTime { get; set; }
    }
}