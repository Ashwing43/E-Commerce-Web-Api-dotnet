using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.Dtos.Product
{
    public class CreateProductDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Length cannot be less than 1.")]
        [MaxLength(50, ErrorMessage = "Length cannot be greater than 50.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000000, ErrorMessage = "Value cannot must be in the range [1, 100000000].")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Value cannot must be in the range [1, 10000].")]
        public int Quantity { get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(250, ErrorMessage = "Length cannot be greater than 250.")]
        public string Description { get; set; } = string.Empty;
    }
}