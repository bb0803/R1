using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.Web.Models.Data
{
    public class Chassis
    {
        [Required]
        public Int32 Id { get; set; }
        public Int32? WorldId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ChassisName { get; set; }
        [Required]
        public Byte Aero { get; set; }
        [Required]
        public Byte Brakes { get; set; }
        [Required]
        public Byte Steering { get; set; }
        public Byte? Status { get; set; }
        public decimal? Cost { get; set; }
        public decimal? ReplacementChassisCost { get; set; }
        public Int32? TeamId { get; set; }
        public Int32? X_TeamId { get; set; }
        public Int32? X_ChassisId { get; set; }
    }
}