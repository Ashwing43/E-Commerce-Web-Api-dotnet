using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Models;

namespace ECommerceWebApi.Dtos
{
    public class UpdateUserDto
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
    }
}