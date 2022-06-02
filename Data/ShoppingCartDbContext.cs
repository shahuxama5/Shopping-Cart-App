using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Data
{
    public class ShoppingCartDbContext : IdentityDbContext<AppUser>
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
