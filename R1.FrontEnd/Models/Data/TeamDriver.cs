using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.Data
{
    public class TeamDriver
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 TeamId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int16 Season { get; set; }
    }
}