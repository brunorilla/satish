using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satish.Models;
using Satish.Data;

namespace Satish.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            :base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
