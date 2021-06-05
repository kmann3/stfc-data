using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using DAL.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;
using StfcWeb.Data.Entities;

namespace StfcWeb.Data
{
    /// <summary>
    /// If you need to rebuild the database then do the following:
    /// Open up SSMS and run the following code to remove all the tables (or you can manually delete them).
    /// <code>
    /*
    DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR
    SET @Cursor = CURSOR FAST_FORWARD FOR
    SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' + tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
    LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME = rc1.CONSTRAINT_NAME
    OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql
    WHILE (@@FETCH_STATUS = 0)
    BEGIN
    Exec sp_executesql @Sql
    FETCH NEXT FROM @Cursor INTO @Sql
    END
    CLOSE @Cursor DEALLOCATE @Cursor
    GO
    EXEC sp_MSforeachtable 'DROP TABLE ?'
    GO
    */
    /// </code>
    /// Then delete the migrations
    /// Then run, in Package Manager Console with the default project set to LotEK_DB:
    /// add-migration init
    /// update-database
    /// // git log  v1520..HEAD --pretty=format:"Date: %ad %s" --stat > LotEK/file/changeLog.txt
    /// // add-migration 000-init -o Data/Migrations -Context LotEKDbContext
    /// // update-database -Context LotEKDbContext
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public static string ConnectionString
        {
            get
            {
#if DEBUG
                return "Data Source=KENNY-MSI-LAPTO;Initial Catalog=StfcWeb;Integrated Security=true;";
#else
            return "";
#endif
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var result = userManager.FindByEmailAsync("kmann@etherpunk.com").Result;
            if (result == null)
            {
                ApplicationUser userKenny = new()
                {
                    UserName = "kmann@etherpunk.com",
                    Email = "kmann@etherpunk.com",
                    EmailConfirmed = true,
                    DisplayName = "Nazadus"
                };

                ApplicationUser userPlayer = new()
                {
                    UserName = "player@gmail.com",
                    Email = "player@gmail.com",
                    EmailConfirmed = true,
                    DisplayName = "Kevin",
                };

                IdentityResult resultKenny = userManager.CreateAsync(userKenny, "Foobarbang!").Result;
                IdentityResult resultPlayer = userManager.CreateAsync(userPlayer, "Foobarbang!").Result;

                string errors = string.Empty;

                if (resultKenny.Succeeded && resultPlayer.Succeeded)
                {
                    userManager.AddToRoleAsync(userKenny, "Admin").Wait();
                    userManager.AddToRoleAsync(userPlayer, "User").Wait();
                }
                else
                {
                    if (resultKenny.Errors.Any())
                    {
                        foreach (var err in resultKenny.Errors)
                        {
                            Console.Write($"Adding Kenny Error: {err}");
                            errors += $"<br />{err}";
                        }
                    }
                    if (resultPlayer.Errors.Any())
                    {
                        errors += "<br />";
                        foreach (var err in resultPlayer.Errors)
                        {
                            Console.Write($"Adding Player Error: {err}");
                            errors += $"<br />{err}";

                        }
                    }
                }

                using ApplicationDbContext dbContext = new();
                News newsItem = new()
                {
                    CreatedById = userKenny.Id,
                    Title = "New Database Generation",
                    TypeCssBg = "",
                    TypeCssText = "text-info",
                    Content = $"A database has been nuked and re-created!{errors}"

                };
                dbContext.News.Add(newsItem);
                dbContext.SaveChanges();
            }
        }
    }


}
}
