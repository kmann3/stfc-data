using Microsoft.EntityFrameworkCore;
using STFCLibrary.Sqlite.Entities;

namespace STFCLibrary.Sqlite;

public class StfcLibDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=stfc.sqlite");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Faction> Factions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Officer> Officers { get; set; }
}
