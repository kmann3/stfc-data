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
            //modelBuilder.HasIndex(k => k.).IsUnique(true);
        }

        public List<OfficerJson.ResourceCost> ToJsonResourceCost()
        {
            List<OfficerJson.ResourceCost> returnData = new();

            if(ActiveNanoprobes != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)ActiveNanoprobes, Type = "Active Nanoprobes" });
            }

            if (IndependantCredits != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)IndependantCredits, Type = "Independant Credits" });
            }

            if (FederationCredits != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)FederationCredits, Type = "Federation Credits" });
            }

            if (RomulanCredits != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)RomulanCredits, Type = "Romulan Credits" });
            }

            if (KlingonCredits != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)KlingonCredits, Type = "Klingon Credits" });
            }

            if (CommandBadges != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)CommandBadges, Type = "Command Badges" });
            }

            if (ScienceBadges != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)ScienceBadges, Type = "Science Badges" });
            }

            if (EngineeringBadges != null)
            {
                returnData.Add(new OfficerJson.ResourceCost() { Count = (long)EngineeringBadges, Type = "Engineering Badges" });
            }

            return returnData;
        }
    }
}
