using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set;} = string.Empty;
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {this.Name}, Price: {this.Price}, Quantity: {this.Quantity}");
        }
    }
}