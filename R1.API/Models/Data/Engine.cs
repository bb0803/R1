using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R1.Services.API.Models.Data
{
    public class Engine
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 WorldId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EngineName { get; set; }
        public Byte? Rating { get; set; }
        public Byte? Power { get; set; }
        public Byte? Status { get; set; }
        public decimal? Cost { get; set; }
        public decimal? AdditionalEngineCost { get; set; }
        public Int32? TeamId { get; set; }
        [Required]
        public Int32 X_EngineId { get; set; }
        public Int32? X_ClassId { get; set; }
        public Int32? X_TeamId { get; set; }
    }
}
