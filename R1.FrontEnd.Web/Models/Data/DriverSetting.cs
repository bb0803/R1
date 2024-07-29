using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.Web.Models.Data
{
    public class DriverSetting
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        public Int32? RaceId { get; set; }
        [Required]
        public Byte DriverMentality { get; set; }
        [Required]
        public Byte BrakingMentality { get; set; }
        public Byte? FrontDownforce { get; set; }
        public Byte? RearDownforce { get; set; }
        public Int32? TyreId { get; set; }
    }
}