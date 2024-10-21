using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Models;

namespace ECommerceWebApi.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Length cannot be less than 1.")]
        [MaxLength(50, ErrorMessage = "Length cannot be greater than 50.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Length cannot be less than 1.")]
        [MaxLength(50, ErrorMessage = "Length cannot be greater than 50.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8, ErrorMessage = "Length cannot be less than 8.")]
        [MaxLength(32, ErrorMessage = "Length cannot be greater than 32.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Range(0, 1, ErrorMessage = "Value need to between [0, 1]")]
        public UserRole Role { get; set; }
    }
}