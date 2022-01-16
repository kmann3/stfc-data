using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFCLibrary.Sqlite.Entities;
public abstract class BaseTable<T> : IEntityTypeConfiguration<T> where T : class
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name")]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Date Created")]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [Display(Name = "Date Created")]
    [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedOnCST
    {
        get
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(CreatedOn, cstZone); ;
        }
    }

    public override string ToString()
    {
        return $"Name: {Name} | ID: {Id}";
    }

    public abstract void Configure(EntityTypeBuilder<T> modelBuilder);

    public void Configure(ModelBuilder modelBuilder)
    {
        Configure(modelBuilder.Entity<T>());
        //modelBuilder.Entity<BasicTable<T>>().HasIndex(x => x.Name);
    }
}
