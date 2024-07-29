using System.ComponentModel.DataAnnotations;

namespace R1.Services.API.Models.Data
{
    public class Series
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 WorldId { get; set; }
        [Required]
        public Int32 X_SeriesId { get; set; }
        [Required]
        public Int32 X_CalendarId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        [MaxLength(20)]
        public string? DateDescription { get; set; } = string.Empty;
    }
}