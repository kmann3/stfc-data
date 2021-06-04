namespace ConsoleTools
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public partial class Officer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

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
        public long ShardsRequired { get; set; }

        [JsonProperty("resource-cost")]
        public List<ResourceCost> ResourceCost { get; set; }

        [JsonProperty("xp")]
        public long? Xp { get; set; }
    }

    public partial class ResourceCost
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public enum TypeEnum { ActiveNanoprobes, EngineeringBadges, IndependentCredits };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Active Nanoprobes":
                    return TypeEnum.ActiveNanoprobes;
                case "Engineering Badges":
                    return TypeEnum.EngineeringBadges;
                case "Independent Credits":
                    return TypeEnum.IndependentCredits;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.ActiveNanoprobes:
                    serializer.Serialize(writer, "Active Nanoprobes");
                    return;
                case TypeEnum.EngineeringBadges:
                    serializer.Serialize(writer, "Engineering Badges");
                    return;
                case TypeEnum.IndependentCredits:
                    serializer.Serialize(writer, "Independent Credits");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
