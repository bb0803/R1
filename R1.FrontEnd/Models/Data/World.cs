using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.Data
{
    public class World
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        public decimal? CashOnHand { get; set; }
    }
}