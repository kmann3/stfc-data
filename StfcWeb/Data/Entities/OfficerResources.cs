using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StfcWeb.Data.Entities
{
    public class OfficerRankResources// : BasicTable<OfficerRankResources>, IEntityTypeConfiguration<OfficerRankResources>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 1)]
        public int Id { get; set; }

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

        public int ActiveNanoprobes { get; set; } = 0;
        public int AugmentCredits { get; set; } = 0;
        public int CommandBadges { get; set; } = 0;
        public int EngineeringBadges { get; set; } = 0;
        public int FederationCredits { get; set; } = 0;
        public int IndependantCredits { get; set; } = 0;
        public int KlingonCredits { get; set; } = 0;
        public int RogueCredits { get; set; } = 0;
        public int RomulanCredits { get; set; } = 0;
        public int ScienceBadges { get; set; } = 0;

        public int Shards { get; set; } = 0;
        public int Xp { get; set; } = 0;

        //public ICollection<Officer> Officers { get; set; }


        //public override void Configure(EntityTypeBuilder<OfficerRankResources> builder)
        //{
        //    builder.HasIndex(k => k.Name).IsUnique(true);
        //}
    }
}
