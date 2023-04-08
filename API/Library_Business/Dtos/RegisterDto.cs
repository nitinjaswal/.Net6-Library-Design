﻿using System.ComponentModel.DataAnnotations;

namespace Library_Business.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime Phone { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
