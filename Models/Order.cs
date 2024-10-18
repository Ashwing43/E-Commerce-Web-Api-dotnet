using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> ProductIds { get; set; } = new List<Guid>();
        public decimal TotalAmount { get; set; }
        public Address Address { get; set; }
        public OrderStatus OrderStatus { set; get; }
    }
}