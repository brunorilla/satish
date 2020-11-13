using Microsoft.EntityFrameworkCore;
using Satish.Data;
using Satish.Models;


namespace Satish.Data
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Cart { get; set; }
    }
}