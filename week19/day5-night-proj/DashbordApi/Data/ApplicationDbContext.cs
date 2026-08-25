
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using DashbordApi.Models;
namespace DashbordApi.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Uav> Uavs { get; set; }
    public DbSet<HostileProccessed> HostileUnits { get; set; }
    public DbSet<TrackProccessed> TrackProccesseds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Uav>()
              .HasMany(e => e.HostileUnits)
              .WithOne(e => e.Uav)
              .HasForeignKey(e => e.model_id)
              .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HostileProccessed>()
            .HasMany(e => e.Tracks)
            .WithOne(e => e.HostileProccessed)
            .HasForeignKey(e => e.unit_id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Uav>()
            .HasKey(e => e.model_id);

        modelBuilder.Entity<HostileProccessed>()
            .HasKey(e => e.unit_id);

        modelBuilder.Entity<TrackProccessed>()
            .HasKey(e => e.track_id);


    }


}