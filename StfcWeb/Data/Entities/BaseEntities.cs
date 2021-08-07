using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StfcWeb.Data.Entities
{
    public abstract class BasicTable<T> : IEntityTypeConfiguration<T> where T : class
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 1)]
        public int Id { get; set; }

        [Required, StringLength(255), Column(Order = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Display(Name = "Date Created"), DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOnCST
        {
            get
            {
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(CreatedOn, cstZone);
            }
        }
        [Required, Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"Name: {Name} | ID: {Id}";
        }

        public abstract void Configure(EntityTypeBuilder<T> modelBuilder);

        public void Configure(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
        }
    }
}
