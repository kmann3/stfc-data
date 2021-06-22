using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StfcWeb.Data.Entities
{
    public class OfficerRankResources : BasicTable<OfficerRankResources>, IEntityTypeConfiguration<OfficerRankResources>
    {
        [Required]
        public int OfficerId { get; set; }
        public Officer Officer { get; set; }
        public int ActiveNanoprobes { get; set } = 0;
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

        public override void Configure(EntityTypeBuilder<OfficerRankResources> builder)
        {
            builder.HasIndex(k => k.Name).IsUnique(true);
        }
    }
}
