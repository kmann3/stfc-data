using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace STFC_Web.Data.Entities
{
    public class RankResourceCost : BasicTable<RankResourceCost>, IEntityTypeConfiguration<RankResourceCost>
    {
        [Description("Active Nanoprobes")]
        public int? ActiveNanoprobes { get; set; }

        [Description("Independant Credits")]
        public int? IndependantCredits { get; set; }

        [Description("Federation Credits")]
        public int? FederationCredits { get; set; }

        [Description("Romulan Credits")]
        public int? RomulanCredits { get; set; }

        [Description("Klingon Credits")]
        public int? KlingonCredits { get; set; }

        [Description("Command Badges")]
        public int? CommandBadges { get; set; }

        [Description("Engineering Badges")]
        public int? EngineeringBadges { get; set; }

        [Description("Science Badges")]
        public int? ScienceBadges { get; set; }

        public override void Configure(EntityTypeBuilder<RankResourceCost> modelBuilder)
        {
            //modelBuilder.HasOne(x => x.Officer).WithOne(x => x.RankResourceCost_1_5).HasForeignKey<Officer>(x => x.Id);
            //modelBuilder.HasOne(x => x.Officer).WithOne(x => x.RankResourceCost_6_10).HasForeignKey<Officer>(x => x.Id);
            //modelBuilder.HasOne(x => x.Officer).WithOne(x => x.RankResourceCost_11_15).HasForeignKey<Officer>(x => x.Id);
            //modelBuilder.HasOne(x => x.Officer).WithOne(x => x.RankResourceCost_16_20).HasForeignKey<Officer>(x => x.Id);
            //modelBuilder.HasOne(x => x.Officer).WithOne(x => x.RankResourceCost_21_30).HasForeignKey<Officer>(x => x.Id);
            modelBuilder.HasIndex(k => k.Name).IsUnique(true);
        }

        public OfficerJSON.ResourceCost ToJSONString()
        {
            OfficerJSON.ResourceCost returnItem = new();
            
            return null;
        }
    }
}
