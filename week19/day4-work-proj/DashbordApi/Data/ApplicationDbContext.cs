using CatalogConsumer.Data;
using CatalogConsumer.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace CatalogConsumer.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Uav> Uavs { get; set; }
    public DbSet<HostileProccessed> HostileUnits { get; set; }
    public DbSet<Track> Tracks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Uav>()
            .HasMany(e => e.HostileUnits)
            .WithOne(e => e.Uav)
            .HasForeignKey(e => e.model_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HostileUnit>()
          .HasMany(e => e.Tracks)
          .WithOne(e => e.HostileUnit)
          .HasForeignKey(e => e.unit_id)
          .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<HostileUnit>()
          .HasKey(e => e.unit_id);


        modelBuilder.Entity<Uav>()
          .HasKey(e => e.model_id);


        modelBuilder.Entity<Track>()
          .HasKey(e => e.track_id);



    }
}