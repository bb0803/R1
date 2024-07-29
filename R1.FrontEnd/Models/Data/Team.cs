using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.Data
{
    public class Team
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 World { get; set; }
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }
        public Int32? Parent { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        public Int32 X_TeamId { get; set; }
        public decimal? Cash { get; set; }
    }
}