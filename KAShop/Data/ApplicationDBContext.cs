using KAShop.Models;
using Microsoft.EntityFrameworkCore;

namespace KAShop.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
       
        public DbSet<Company> companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Server=.;Database=KAShop_MVC;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mobiles" },
                new Category { Id = 2, Name = "Laptops" } ,
                new Category { Id = 3, Name = "Cameras" },
                new Category { Id = 4, Name = "Tablets" },
                new Category { Id = 5, Name = "Accessories" }
                );
        }
    }
}
