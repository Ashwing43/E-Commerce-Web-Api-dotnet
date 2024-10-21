using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceWebApi.Models;

namespace ECommerceWebApi.Dtos.User
{
    public class GetUserCustomerDto : GetUserDto
    {
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}