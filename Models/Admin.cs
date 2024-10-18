using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.Models
{
    public class Admin : User
    {

        #region Methods
        public override void DisplayInfo()
        {
            Console.WriteLine("\nAdmin Info: ");
            Console.WriteLine($"Admin name : {this.Name}");
            Console.WriteLine($"Admin email : {this.Email}");
        }
        #endregion
    }
}