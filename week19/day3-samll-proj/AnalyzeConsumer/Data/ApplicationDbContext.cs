using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using AnalyzeConsumer.Models;

namespace AnalyzeConsumer.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {
    }
    public DbSet<Analysts> Analysts { get; set; }
    public DbSet<Calls> Calls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analysts>()
            .HasMany(e => e.Calls)
            .WithOne(e => e.Analysts)
            .HasForeignKey(c => c.analyst_id)
             .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Analysts>()
            .HasKey(e => e.analyst_id);

        modelBuilder.Entity<Calls>()
            .HasKey(e => e.call_id);

    }
}