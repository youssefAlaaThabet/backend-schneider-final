using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amason.help.dtos
{
    public class CartDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }

    }
}
