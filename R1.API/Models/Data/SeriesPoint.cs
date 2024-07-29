using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class SeriesPoint
    {
        [Required, Key]
        public Int32 Id { get; set; }
        [Required]
        public Int32 SeriesId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int16 Points { get; set; }
        [Required]
        public Byte Position { get; set; }
    }
}
