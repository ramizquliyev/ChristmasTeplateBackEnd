using CristmasTeplate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CristmasTeplate.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        public DbSet<Setting> Settings { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        
    }
}
