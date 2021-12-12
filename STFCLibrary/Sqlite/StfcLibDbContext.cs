using Microsoft.EntityFrameworkCore;
using STFCLibrary.Sqlite.Entities;

namespace STFCLibrary.Sqlite;
internal class StfcLibDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=stfc.sqlite");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Class> Classes { get; set; }
}
