using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amason.Models
{
      
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }
        public string Gender { get; set; }


        public ICollection<Cart> CartUser { get; set; }
        public ICollection<Shipping> ShippingUser { get; set; }



    }
}
