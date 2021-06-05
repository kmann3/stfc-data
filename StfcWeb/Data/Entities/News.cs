using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StfcWeb.Data.Entities
{
    public class News : IEntityTypeConfiguration<News>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
            return $"Title: {Title} | ID: {Id}";
        }

        [Required]
        public string Content { get; set; } = string.Empty;

        public string Title { get; set; }

        public string TypeCssBg { get; set; } = string.Empty;
        public string TypeCssText { get; set; } = string.Empty;

        public enum TypeClass
        {
            Primary,
            Secondary,
            Success,
            Danger,
            Warning,
            Info,
            Light,
            Dark,
            White,
            Black,
            [Description("")]
            Empty,
        }

        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }

        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasOne(a => a.CreatedBy).WithMany(u => u.NewsCreatedBy).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
