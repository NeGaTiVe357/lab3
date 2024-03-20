using lab3.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace lab3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategories> Product_categories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Устанавливаем связь между таблицами Product и ProductCategories
            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductCategories)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.IdProduct).IsRequired();
            modelBuilder.Entity<Category>()
                .HasMany(e => e.ProductCategories)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.IdCategories).IsRequired();
        }
    }
}