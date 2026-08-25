using Microsoft.EntityFrameworkCore;
using ECommerceApi.Models;

namespace ECommerceApi.Data;

public class ECommerceApi : DbContext
{
    public ECommerceApi(DbContextOptions<ECommerceApi> options)
        : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Review> Reviewies { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasOne(p => p.Category)
                // A Product has one Category
                .WithMany(c => c.Products)
                // A Category has many Products
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>().HasOne(r => r.Product)
            // A Review has one Product
            .WithMany(p => p.Reviews)
            // A Product has many Reviews
            .HasForeignKey(r => r.ProductId).OnDelete(DeleteBehavior.Cascade);


        // Seed data - deliberately modest. Today's lesson is about query
        // COUNT and correctness, not raw timing, so we don't need thousands
        // of rows. Watch the console log, not the clock.

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Books" },
            new Category { Id = 3, Name = "Clothing" }
        );

        var products = new List<Product>();

        for (int i = 1; i <= 30; i++)
        {
            products.Add(
                new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Price = 10m + (i * 5),
                    StockQuantity = 100 - i,
                    CategoryId = ((i - 1) % 3) + 1
                }
            );
        }
        modelBuilder.Entity<Product>().HasData(products);

        var reviews = new List<Review>();

        for (int i = 1; i <= 90; i++)
        {
            reviews.Add(
                new Review
                {
                    Id = i,
                    ProductId = ((i - 1) % 30) + 1,
                    ReviewerName = $"User {i}",
                    Rating = (i % 5) + 1
                }
            );
        }

        modelBuilder.Entity<Review>().HasData(reviews);
    }

        




}