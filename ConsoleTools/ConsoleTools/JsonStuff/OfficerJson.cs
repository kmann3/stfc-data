namespace ConsoleTools
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public partial class OfficerJson
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lastModified")]
        public string LastModified { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("faction")]
        public string Faction { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("synergy-command")]
        public int SynergyCommand { get; set; }

        [JsonProperty("synergy-engineering")]
        public int SynergyEngineering { get; set; }

        [JsonProperty("synergy-science")]
        public int SynergyScience { get; set; }

        [JsonProperty("ranks")]
        public Dictionary<string, Rank> Ranks { get; set; }

        [JsonProperty("captain-maneuver")]
        public CaptainManeuver CaptainManeuver { get; set; }

        [JsonProperty("officer-ability")]
        public OfficerAbility OfficerAbility { get; set; }

        [JsonProperty("stats")]
        public Dictionary<string, Stat> Stats { get; set; }
        [JsonProperty("image-url")]
        public string ImageUrl { get; set; }
    }

    public partial class CaptainManeuver
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description:")]
        public string Description { get; set; }
    }

    public partial class OfficerAbility
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description_text")]
        public string DescriptionText { get; set; }

        [JsonProperty("description_value1")]
        public int? DescriptionValue1 { get; set; }

        [JsonProperty("description_value2")]
        public int? DescriptionValue2 { get; set; }

        [JsonProperty("description_value3")]
        public int? DescriptionValue3 { get; set; }

        [JsonProperty("description_value4")]
        public int? DescriptionValue4 { get; set; }

        [JsonProperty("description_value5")]
        public int? DescriptionValue5 { get; set; }
    }

    public partial class Rank
    {
        [JsonProperty("shards-required")]
        public long ShardsRequired { get; set; }

        [JsonProperty("resource-cost")]
        public List<ResourceCost> ResourceCost { get; set; }

        [JsonProperty("xp")]
        public long Xp { get; set; }
    }

    public partial class ResourceCost
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public partial class Stat
    {
        [JsonProperty("Attack")]
        public int? Attack { get; set; }

        [JsonProperty("Defense")]
        public int? Defense { get; set; }

        [JsonProperty("Health")]
        public int? Health { get; set; }
    }
}