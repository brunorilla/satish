using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Satish.Models
{
    public class Product
    {
        public string Id { get; set;}
        public string Name { get; set;}
        public string Image { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
}
