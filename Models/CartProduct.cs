using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Satish.Models
{
    public class CartProduct
    {
        public DateTime TimeStamp { get; set; }
        public int CartProductId { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

    }
}
