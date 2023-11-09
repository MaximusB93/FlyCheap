using FlyCheap.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlyCheap.Db;

public class AirportsDbContext : DbContext
{
    public DbSet<AirportsJson> DataAirports { get; set; }

    private readonly string ConnectionString =
        "Host=pg3.sweb.ru;Username=maksimbudn;Password=QU3WLCGWFbWRG$S8;Database=maksimbudn";

    /*public AirportsDbContext()
    {
        Database.EnsureCreated();
    }*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coordinates>()
            .HasKey(c => c.CoordinatesId); // Замените CoordinatesId на имя свойства, которое вы хотите использовать в качестве первичного ключа

        // Другие настройки модели...

        base.OnModelCreating(modelBuilder);
    }
}