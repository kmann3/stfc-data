using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFC_Web.Data
{
    public abstract class BasicTable<T> : BaseEntity, IEntityTypeConfiguration<T> where T : class
    {
        

        public abstract void Configure(EntityTypeBuilder<T> modelBuilder);

        public void Configure(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
            //modelBuilder.Entity<BasicTable<T>>().HasIndex(x => x.Name);
        }
    }

    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = RT.Comb.Provider.Sql.Create();

        [Required]
        [Display(Name = "Name")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Display(Name = "Date Created CST")]
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOnCST
        {
            get
            {
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(CreatedOn, cstZone); ;
            }
        }

        [Required, Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Modified CST")]
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedCST
        {
            get
            {
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(LastModified, cstZone); ;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name} | ID: {Id}";
        }
    }
}
