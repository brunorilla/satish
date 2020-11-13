﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Satish.Models
{
    public class Cart
    {
        [Key]
        public int Id_cart  { get; set; }
        public int Id_AspNetUsers { get; set; }

        public bool estado { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}