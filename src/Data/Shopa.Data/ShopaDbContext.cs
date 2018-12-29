using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopa.Data.Models;

namespace Shopa.Data
{
    public class ShopaDbContext : IdentityDbContext<ShopaUser>
    {
        public ShopaDbContext(DbContextOptions<ShopaDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Quantity> Quantities { get; set; }

        public DbSet<Balance> Balances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Store>().HasKey(k=>k.)
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
