    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

namespace STFC_Web.Data.Entities
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public partial class StfcOfficerJson
    {
        [JsonProperty("author-comment")]
        public string AuthorComment { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("lastModified")]
        public DateTimeOffset LastModified { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("faction")]
        public string Faction { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("synergy-command")]
        public long SynergyCommand { get; set; }

        [JsonProperty("synergy-engineering")]
        public long SynergyEngineering { get; set; }

        [JsonProperty("synergy-science")]
        public long SynergyScience { get; set; }

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

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rank")]
        public Dictionary<string, long> Rank { get; set; }
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
}
