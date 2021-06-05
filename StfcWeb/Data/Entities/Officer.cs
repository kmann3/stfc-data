using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StfcWeb.Data.Entities
{
    public class Officer : BasicTable<Officer>, IEntityTypeConfiguration<Officer>
    {
        //public Class Class { get; set; }
        //public Faction Faction {get;set;}
        //public Rarity Rarity { get; set; }
        //public List<Tags> Tags { get; set; }

        public int SynergyCommand { get; set; }
        public int SynergyEngineering { get; set; }
        public int SynergyScience { get; set; }

        public int Rank1Shards { get; set; }
        public int Rank1Xp { get; set; }
        //public ResourceType Rank1ReourseCost1Type { get; set; }
        public int Rank1ReousrceCost1Count { get; set; }

        public string CaptainManeuverName { get; set; }
        public string CaptainManeuverDescription { get; set; }

        public string OfficerAbilityName { get; set; }
        public string OfficerAbilityDescRank1 { get; set; }
        public string OfficerAbilityDescRank2 { get; set; }
        public string OfficerAbilityDescRank3 { get; set; }
        public string OfficerAbilityDescRank4 { get; set; }
        public string OfficerAbilityDescRank5 { get; set; }
        
        public string ImageUrl { get; set; }

        public override void Configure(EntityTypeBuilder<Officer> builder)
        {
            builder.HasIndex(k => k.Name).IsUnique(true);
        }

        public OfficerJson ToJson()
        {
            OfficerJson returnOfficer = new();

            throw new NotImplementedException();
        }
    }
}
