using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Dto
{
    public class AvailableEngineDto
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string EngineName { get; set; }
        public Byte? Rating { get; set; }
        public Byte? Power { get; set; }
        public decimal? Cost { get; set; }
        public decimal? AdditionalEngineCost { get; set; }
        public Int32? X_ClassId { get; set; }
    }
}
