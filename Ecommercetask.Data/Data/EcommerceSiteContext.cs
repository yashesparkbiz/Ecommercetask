

using Ecommercetask.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommercetask.Data.Data
{
    public class EcommerceSiteContext : IdentityDbContext<UserModel, IdentityRole<int>, int> 
    {
        public EcommerceSiteContext(DbContextOptions<EcommerceSiteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserModel>().ToTable("Users");
        }

        public DbSet<User> User { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Discount> Discount { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order_Details> Order_Details { get; set; }

        public DbSet<Product_wishlist> Product_wishlist { get; set; }

        public DbSet<Product_category> Product_category { get; set; }

        public DbSet<Product_subcategory> Product_subcategory { get; set; }

        public DbSet<Product_cart> Product_cart { get; set; }
    }
}
