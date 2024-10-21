using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.QueryObjects
{
    public class QueryObject
    {
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public int Quantity { get; set; }
    }
}