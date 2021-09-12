using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amason.Models
{
    
public class Shipping
    {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Address { get; set; }
        public User user { get; set; }

    }
}
