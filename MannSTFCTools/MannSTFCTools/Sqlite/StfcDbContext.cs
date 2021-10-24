using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MannSTFCTools.Sqlite
{
    //add-migration init -o Sqlite/Migrations
    internal class StfcDbContext : DbContext
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
}
