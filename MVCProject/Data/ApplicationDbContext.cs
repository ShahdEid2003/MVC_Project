using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;DataBase=MVCProject;TrustServerCertificate=True;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mobile" },
                new Category { Id = 2, Name = "Cameras" },
                new Category { Id = 3, Name = "Tablets" },
                new Category { Id = 4, Name = "Laptops" },
                new Category { Id = 5, Name = "Accessories" }


                );

        }
    }
}
