﻿using System.ComponentModel.DataAnnotations;

namespace diploma.Db.Tour.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
