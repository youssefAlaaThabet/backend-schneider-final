using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amason.Models
{
    

public class Cart
    {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Number { get; set; }

    public User user { get; set; }
    public Product product { get; set; }

    }
}
