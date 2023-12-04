using ally.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ally.DAL
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):IdentityDbContext<User>(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SessionToken> Tokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Cart> ShoppingCart { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<UpperCategory> UpperCategories { get; set; }
        public DbSet<Slider> Sliders { get; set; }

    }
}