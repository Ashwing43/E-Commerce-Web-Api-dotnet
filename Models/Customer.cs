using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.Models
{
    public class Customer : User
    {
        #region Fields
        // public List<Address> Addresses = new List<Address>();
        
        public Queue<string> notifications = new Queue<string>();
        #endregion

        #region Methods
        public override void DisplayInfo()
        {
            Console.WriteLine("\nCustomer Info: ");
            Console.WriteLine($"Customer name : {this.Name}");
            Console.WriteLine($"Customer email : {this.Email}");
        }
        #endregion
    }
}