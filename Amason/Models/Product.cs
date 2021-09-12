using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amason.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public ICollection<Cart> CartProduct { get; set; }




    }
}
