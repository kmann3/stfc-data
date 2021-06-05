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

        [JsonProperty("description_rank1")]
        public string DescriptionRank1 { get; set; }

        [JsonProperty("description_rank2")]
        public string DescriptionRank2 { get; set; }

        [JsonProperty("description_rank3")]
        public string DescriptionRank3 { get; set; }

        [JsonProperty("description_rank4")]
        public string DescriptionRank4 { get; set; }

        [JsonProperty("description_rank5")]
        public string DescriptionRank5 { get; set; }
    }

    public partial class Rank
    {
        [JsonProperty("shards-required")]
        public int ShardsRequired { get; set; }

        [JsonProperty("resource-cost")]
        public List<ResourceCost> ResourceCost { get; set; }

        [JsonProperty("xp")]
        public int Xp { get; set; }
    }

    public partial class ResourceCost
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
