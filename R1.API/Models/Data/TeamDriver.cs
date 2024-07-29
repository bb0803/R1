using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class TeamDriver
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 WorldId { get; set; }
        [Required]
        public Int32 TeamId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int16 Season { get; set; }
    }
}