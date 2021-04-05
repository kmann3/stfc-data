using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STFC_Web.Data
{
    public class Seeds
    {
        public static Entities.Class Class_Command = new() { Name = "Command", Id = Guid.Parse("de824ea7-0cb1-4fbb-b04e-b4b111a2ef9c") };
        public static Entities.Class Class_Engineering = new() { Name = "Engineering", Id = Guid.Parse("15a6f9a2-0b10-4f2a-970c-79680fa2f79f") };
        public static Entities.Class Class_Science = new() { Name = "Science", Id = Guid.Parse("631777d7-a81f-4eca-807a-5f45296f2c9d") };

        public static Entities.Tags Tag_Neutral = new() { Name = "neutral", Id = Guid.Parse("a639f679-fb2f-49a1-a22c-a0e159a45ce8") };
        public static Entities.Tags Tag_ShieldMitigation = new() { Name = "shield-mitigation", Id = Guid.Parse("d0adb0b8-17cb-4847-8e53-a8b5096d83d9") };
        public static Entities.Tags Tag_Shields = new() { Name = "shields", Id = Guid.Parse("3d112cea-2192-4c58-b201-f798e4ba9725") };
        public static Entities.Tags Tag_ProtectedCargo = new() { Name = "protected-cargo", Id = Guid.Parse("1b20a8f0-8ca0-4854-9a58-2dadf14d7f9e") };
        public static Entities.Tags Tag_Mining = new() { Name = "mining", Id = Guid.Parse("3e7e933c-bada-4f87-af55-a03103d3e82b") };

        public static Entities.Faction Faction_Federation = new() { Name = "Federation", Id = Guid.Parse("316bc45f-4a67-4912-927c-03e5d8fd4946") };
        public static Entities.Faction Faction_Neutral = new() { Name = "Neutral", Id = Guid.Parse("4473b683-4c3f-4a6e-94ee-0008cb84cdca") };

        public static Entities.Rarity Rarity_Rare = new() { Name = "Rare", Id = Guid.Parse("cf42ef79-3cf9-4bab-b862-e7728e47e588") };
        public static Entities.RankResourceCost RRC_6_10 = new() { ActiveNanoprobes = 3000, Id = Guid.Parse("8ea26ea6-2ec0-4c3d-88b1-f0724f88436c") };
        public static Entities.RankResourceCost RRC_11_15 = new() { ActiveNanoprobes = 25000, IndependantCredits = 1300, CommandBadges = 1, Id = Guid.Parse("d6cb60f0-35af-42b0-b9e3-73b09a08ec8e") };
        public static Entities.RankResourceCost RRC_16_20 = new() { ActiveNanoprobes = 100000, IndependantCredits = 5200, EngineeringBadges = 2, Id = Guid.Parse("837d07cc-0e79-452e-8914-734591304780") };
        public static Entities.RankResourceCost RRC_22_30 = new() { ActiveNanoprobes = 500000, IndependantCredits = 13000, EngineeringBadges = 4, Id = Guid.Parse("f6d8ce96-269f-4822-a21a-c0376ecf830f") };

        public static Entities.Officer Officer_OneOfTen = new()
        {
            Id = Guid.Parse("68aa72df-cc98-418b-a195-b7bd5100de74"),
            CreatedOn = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
            Name = "One of Ten",
            Class = Class_Command,
            //ClassId = Class_Command.Id,
            Description = "An engineer assigned to active duty aboard the USS Westchester, Daniel Morgan was a promising young officer with a potentially bright future in Starfleet Operations. However when the Westchester encountered the Borg in the mid 23rd century, this future was irrevocable altered. With his fellow crewmates quickly assimilated into the Borg Collective, Morgan was the last to undergo this procedure. With a fateful last-minute intervention from a Starfleet rescue fleet, the assimilation of Morgan was interrupted and he returned to the care of the Federation. With both the memories and scars of the incident now a party of him for the rest of his life, Morgan uses his brief experience as part of the Collective in order to combat the Borg threat.",
            Faction = Faction_Federation,
            Rarity = Rarity_Rare,
            Tags = new List<Entities.Tags>() { Tag_Neutral, Tag_ShieldMitigation, Tag_Shields, Tag_ProtectedCargo, Tag_Mining },
            SynergyCommand = 1,
            SynergyEngineering = 2,
            SynergyScience = 2,

            RankResourceCost_1_5 = null,
            RankShardsReq_1_5 = 40,
            RankXP_1_5 = null,

            RankResourceCost_6_10 = RRC_6_10,
            RankShardsReq_6_10 = 65,
            RankXP_6_10 = null,

            RankResourceCost_11_15 = RRC_11_15,
            RankShardsReq_11_15 = 125,
            RankXP_11_15 = null,

            RankResourceCost_16_20 = RRC_16_20,
            RankShardsReq_16_20 = 170,
            RankXP_16_20 = null,

            RankResourceCost_21_30 = RRC_22_30,
            RankShardsReq_21_30 = 250,
            RankXP_21_30 = null,

            OfficerAbilityName = "Bodyguard",
            OfficerAbilityDescription = "+[%i]% to the Protected Cargo of the ship",
            OfficerAbilityRank1Value = 30,
            OfficerAbilityRank2Value = 35,
            OfficerAbilityRank3Value = 40,
            OfficerAbilityRank4Value = 45,
            OfficerAbilityRank5Value = 50,

            CaptainManeuverName = "Adaptive Shielding",
            CaptainManeuverDescription = "+5% damage mitigated by the shields.",

            Image = System.IO.File.ReadAllBytes(Environment.CurrentDirectory + "\\Data\\OneOfTen.png"),
        };
    }
}
