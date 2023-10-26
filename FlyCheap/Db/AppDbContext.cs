using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlyCheap;

public class AppDbContext: DbContext
{
    public DbSet<_1> DataTickets { get; set; }

    private readonly string ConnectionString = "Host=pg3.sweb.ru;Username=maksimbudn;Password=QU3WLCGWFbWRG$S8;Database=maksimbudn";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        
    }
}