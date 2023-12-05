using System;
using FlyCheap.Models.Db;
using FlyCheap.Models.JsonModel;
using FlyCheap.Models.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlyCheap.Db;

public class AirDbContext : DbContext
{
    public DbSet<Airports> Airports { get; set; }
    public DbSet<Airlines> Airlines { get; set; }
    public DbSet<Cities> Cities { get; set; }
    public DbSet<Countries> Countries { get; set; }

    private readonly string ConnectionString =
        "Host=pg3.sweb.ru;Username=maksimbudn;Password=QU3WLCGWFbWRG$S8;Database=maksimbudn";

    // public AirDbContext()
    // {
    //     Database.EnsureCreated();
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coordinates>()
            .HasKey(c => c.lat);

        modelBuilder.Entity<Cases>().HasKey(x => x.da);
        modelBuilder.Entity<NameTranslations>().HasKey(x => x.en);
        //modelBuilder.Entity<>
        
        //base.OnModelCreating(modelBuilder);
    }
}