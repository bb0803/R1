﻿using System.ComponentModel.DataAnnotations;

namespace R1.FrontEnd.WA.Models.Data
{
    public class TeamDevelopment
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 TeamId { get; set; }
        public Byte? Aero { get; set; }
        public Byte? Brakes { get; set; }
        public Byte? Chassis { get; set; }
        public Byte? Suspension { get; set; }
        public Byte? Steering { get; set; }
    }
}