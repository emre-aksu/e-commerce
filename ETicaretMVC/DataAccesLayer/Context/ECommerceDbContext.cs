using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;

namespace DataAccesLayer.Context
{
    public class ECommerceDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=Monster;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ProductPhoto için composite key tanımı
            //modelBuilder.Entity<ProductPhoto>()
            //            .HasKey(x => new { x.ProductId, x.PhotoPath });

        }
    }
}
