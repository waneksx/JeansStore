using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class CartLine
    {
        public Jeans Jeans { get; set; }
        public int Quantity { get; set; }
    }
}
