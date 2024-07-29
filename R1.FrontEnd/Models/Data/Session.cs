using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.Data
{
    public class Session
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Byte ClassId { get; set; }
        [Required]
        public Int32 CircuitId { get; set; }
        [Required]
        public Int16 Season { get; set; }
        public Int32? SeriesId { get; set; }
        [Required]
        public Byte Round { get; set; }
        [MaxLength(20)]
        public string? SessionType { get; set; } = string.Empty;
        [Required]
        public Byte Race { get; set; }
    }
}