using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class Practice
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 SeriesId { get; set; }
        [Required]
        public Byte PracticeNo { get; set; }
    }
}