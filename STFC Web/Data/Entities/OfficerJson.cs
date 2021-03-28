using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace STFC_Web.Data.Entities
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class OfficerJSON
    {
        public class _1
        {
            [JsonPropertyName("level-range")]
            public string LevelRange { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("shards-required")]
            public int ShardsRequired { get; set; }

            [JsonPropertyName("resource-cost")]
            public object ResourceCost { get; set; }

            [JsonPropertyName("xp")]
            public int Xp { get; set; }
        }

        public class _2
        {
            [JsonPropertyName("level-range")]
            public string LevelRange { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("shards-required")]
            public int ShardsRequired { get; set; }

            [JsonPropertyName("resource-cost")]
            public object ResourceCost { get; set; }

            [JsonPropertyName("xp")]
            public int Xp { get; set; }
        }

        public class _3
        {
            [JsonPropertyName("level-range")]
            public string LevelRange { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("shards-required")]
            public int ShardsRequired { get; set; }

            [JsonPropertyName("resource-cost")]
            public object ResourceCost { get; set; }

            [JsonPropertyName("xp")]
            public int Xp { get; set; }
        }

        public class _4
        {
            [JsonPropertyName("level-range")]
            public string LevelRange { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("shards-required")]
            public int ShardsRequired { get; set; }

            [JsonPropertyName("resource-cost")]
            public object ResourceCost { get; set; }

            [JsonPropertyName("xp")]
            public int Xp { get; set; }
        }

        public class ResourceCost
        {
            [JsonPropertyName("federation-credits")]
            public int FederationCredits { get; set; }
        }

        public class _5
        {
            [JsonPropertyName("level-range")]
            public string LevelRange { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("shards-required")]
            public int ShardsRequired { get; set; }

            [JsonPropertyName("resource-cost")]
            public ResourceCost ResourceCost { get; set; }

            [JsonPropertyName("xp")]
            public int Xp { get; set; }
        }

        public class Rank
        {
            [JsonPropertyName("1")]
            public _1 _1 { get; set; }

            [JsonPropertyName("2")]
            public _2 _2 { get; set; }

            [JsonPropertyName("3")]
            public _3 _3 { get; set; }

            [JsonPropertyName("4")]
            public _4 _4 { get; set; }

            [JsonPropertyName("5")]
            public _5 _5 { get; set; }
        }

        public class CaptainManeuver
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("description:")]
            public string Description { get; set; }
        }

        public class OfficerAbility
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("rank")]
            public Rank Rank { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("guid")]
            public string Guid { get; set; }

            [JsonPropertyName("lastModified")]
            public DateTime LastModified { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("class")]
            public string Class { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("faction")]
            public string Faction { get; set; }

            [JsonPropertyName("group")]
            public string Group { get; set; }

            [JsonPropertyName("rarity")]
            public string Rarity { get; set; }

            [JsonPropertyName("tags")]
            public List<string> Tags { get; set; }

            [JsonPropertyName("synergy-command")]
            public int SynergyCommand { get; set; }

            [JsonPropertyName("synergy-engineering")]
            public int SynergyEngineering { get; set; }

            [JsonPropertyName("synergy-science")]
            public int SynergyScience { get; set; }

            [JsonPropertyName("rank")]
            public Rank Rank { get; set; }

            [JsonPropertyName("captain-maneuver")]
            public CaptainManeuver CaptainManeuver { get; set; }

            [JsonPropertyName("officer-ability")]
            public OfficerAbility OfficerAbility { get; set; }

            [JsonPropertyName("image-url")]
            public string ImageUrl { get; set; }
        }
    }
}
