#nullable enable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFC_Web.Data.Entities
{
    public class Officer : BasicTable<Officer>, IEntityTypeConfiguration<Officer>
    {
        public Class? Class { get; set; }

        public string? Description { get; set; }

        public Faction? Faction { get; set; }
        public Group? Group { get; set; }
        public Rarity? Rarity { get; set; }

        public int? SynergyCommand { get; set; }
        public int? SynergyEngineering { get; set; }
        public int? SynergyScience { get; set; }

        // Ranks
        public string? RankName_1_5 { get; set; }
        public int? RankShardsReq_1_5 { get; set; }
        public int? RankXP_1_5 { get; set; }
        public Guid? RankResourceCost_1_5Id { get; set; }
        public RankResourceCost? RankResourceCost_1_5 { get; set; }

        public string? RankName_6_10 { get; set; }
        public int? RankShardsReq_6_10 { get; set; }
        public int? RankXP_6_10 { get; set; }
        public Guid? RankResourceCost_6_10Id { get; set; }
        public RankResourceCost? RankResourceCost_6_10 { get; set; }

        public string? RankName_11_15 { get; set; }
        public int? RankShardsReq_11_15 { get; set; }
        public int? RankXP_11_15 { get; set; }
        public Guid? RankResourceCost_11_15Id { get; set; }
        public RankResourceCost? RankResourceCost_11_15 { get; set; }

        public string? RankName_16_20 { get; set; }
        public int? RankShardsReq_16_20 { get; set; }
        public int? RankXP_16_20 { get; set; }
        public Guid? RankResourceCost_16_20Id { get; set; }
        public RankResourceCost? RankResourceCost_16_20 { get; set; }

        public string? RankName_21_30 { get; set; }
        public int? RankShardsReq_21_30 { get; set; }
        public int? RankXP_21_30 { get; set; }
        public Guid? RankResourceCost_21_30Id { get; set; }
        public RankResourceCost? RankResourceCost_21_30 { get; set; }

        public string? CaptainManeuverName { get; set; }
        public string? CaptainManeuverDescription { get; set; }

        public string? OfficerAbilityName { get; set; }
        public string? OfficerAbilityDescription { get; set; }
        public int? OfficerAbilityRank1Value { get; set; }
        public int? OfficerAbilityRank2Value { get; set; }
        public int? OfficerAbilityRank3Value { get; set; }
        public int? OfficerAbilityRank4Value { get; set; }
        public int? OfficerAbilityRank5Value { get; set; }

        public byte[]? Image { get; set; }

        public ICollection<Tags> Tags { get; set; }

        [NotMapped]
        public bool IsComplete
        {
            get
            {
                return Class != null && !String.IsNullOrEmpty(Description) &&
                    Faction != null && Group != null && Rarity != null &&
                    !String.IsNullOrWhiteSpace(RankName_1_5) && RankShardsReq_1_5 != null && RankXP_1_5 != null && //RankResourceCost_1_5 != null &&
                    !String.IsNullOrWhiteSpace(RankName_6_10) && RankShardsReq_6_10 != null && RankXP_6_10 != null && //RankResourceCost_6_10 != null &&
                    !String.IsNullOrWhiteSpace(RankName_11_15) && RankShardsReq_11_15 != null && RankXP_11_15 != null && //RankResourceCost_11_15 != null &&
                    !String.IsNullOrWhiteSpace(RankName_16_20) && RankShardsReq_16_20 != null && RankXP_16_20 != null && //RankResourceCost_16_20 != null &&
                    !String.IsNullOrWhiteSpace(RankName_21_30) && RankShardsReq_21_30 != null && RankXP_21_30 != null && //RankResourceCost_21_30 != null &&
                    SynergyCommand != null && SynergyEngineering != null && SynergyScience != null &&
                    !String.IsNullOrWhiteSpace(CaptainManeuverName) && !String.IsNullOrWhiteSpace(CaptainManeuverDescription) &&
                    !String.IsNullOrWhiteSpace(OfficerAbilityName) && !String.IsNullOrWhiteSpace(OfficerAbilityDescription) &&
                    OfficerAbilityRank1Value != null && OfficerAbilityRank2Value != null && OfficerAbilityRank3Value != null && OfficerAbilityRank4Value != null && OfficerAbilityRank5Value != null &&
                    // Ranks
                    Image != null && Tags.Count > 0;
            }
        }

        [NotMapped]
        public string ToJSON
        {
            get
            {
                OfficerJSON.Root returnData = new();
                returnData.Guid = Id.ToString();
                returnData.LastModified = LastModified;
                returnData.Name = Name;
                
                returnData.CaptainManeuver = new OfficerJSON.CaptainManeuver()
                {
                    Name = CaptainManeuverName ?? "",
                    Description = CaptainManeuverDescription ?? ""
                };
                returnData.Class = Class?.Name ?? "";
                returnData.Description = Description;
                returnData.Faction = Faction?.Name ?? "";
                returnData.Group = Group?.Name ?? "";
                returnData.ImageUrl = ""; // TBI
                returnData.OfficerAbility = new OfficerJSON.OfficerAbility()
                {
                    Name = OfficerAbilityName ?? "",
                    Description = OfficerAbilityDescription ?? "",
                    Rank = new OfficerJSON.Rank()
                    {
                        _1 = new OfficerJSON._1()
                        {
                            LevelRange = "1-5",
                            Name = RankName_1_5 ?? "",
                            //ResourceCost = RankResourceCost_1_5.Name ?? "",
                            ShardsRequired = RankShardsReq_1_5 ?? -1,
                            Xp = RankXP_1_5 ?? -1
                        }
                    }
                };


                return returnData?.ToString() ?? "";
            }
        }

        public override void Configure(EntityTypeBuilder<Officer> builder)
        {
            builder.HasMany(x => x.Tags).WithMany(x => x.Officers).UsingEntity(x => x.ToTable("Link_Officer_Tag"));

            builder.HasIndex(k => k.Name).IsUnique(true);
        }
    }
}
