using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Satish.Models
{
    public class CartProduct
    {
        [AllowNull]
        public DateTime TimeStamp { get; set; }
        [Key]
        public int CartProductId { get; set; }
        [AllowNull]
        public int CartId { get; set; }
        [AllowNull]
        public Cart Cart { get; set; }
        [AllowNull]
        public string ProductId { get; set; }
        [AllowNull]
        public Product Product { get; set; }

    }
}
