using Newtonsoft.Json;
using STFCLibrary.Util;

namespace STFCLibrary.JsonClasses;
public class Officer
{
    public class JsonOfficer : JsonHelper<JsonOfficer>.IJsonBase
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ability_info")]
        public AbilityInfo AbilityInfo { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("faction")]
        public string Faction { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("img_url")]
        public string ImgUrl { get; set; }

        [JsonProperty("officer_name")]
        public string OfficerName { get; set; }

        [JsonProperty("ranks")]
        public List<Rank> Ranks { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("synergy")]
        public Synergy Synergy { get; set; }

        [JsonProperty("traits")]
        public List<Trait> Traits { get; set; }

        public string Name => this.OfficerName;

        public override string ToString()
        {
            return this.Name;
        }
    }
    public class AbilityInfo
    {
        [JsonProperty("captain_maneuver")]
        public CaptainManeuver CaptainManeuver { get; set; }

        [JsonProperty("officer_ability")]
        public OfficerAbility OfficerAbility { get; set; }

        public override string ToString()
        {
            return $"[AbilityInfo] Capt: {CaptainManeuver} | Off: {OfficerAbility}";
        }
    }

    public class CaptainManeuver
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("buff")]
        public Buff Buff { get; set; }

        [JsonProperty("bonus")]
        public string Bonus { get; set; }

        [JsonProperty("percentage")]
        public bool Percentage { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        public override string ToString()
        {
            return $"[Cap Man] Name: {Name} | Buff: {Buff}";
        }
    }

    public class OfficerAbility
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("buff")]
        public Buff Buff { get; set; }

        [JsonProperty("bonus")]
        public string Bonus { get; set; }

        [JsonProperty("percentage")]
        public bool Percentage { get; set; }

        public override string ToString()
        {
            return $"[Off Ability] Name: {Name} | Buff: {Buff}";
        }
    }

    public partial class Buff
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public override string ToString()
        {
            return $"[Buff] Name: {Name} | Type: {Type}";
        }
    }

    public class Rank
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("officer_ability_value")]
        public double OfficerAbilityValue { get; set; }

        [JsonProperty("rank_id")]
        public int RankId { get; set; }

        [JsonProperty("requirements")]
        public Requirements Requirements { get; set; }

        public override string ToString()
        {
            return $"[Rank] Name: {Name} | Value: {OfficerAbilityValue}";
        }
    }

    public class Requirements
    {
        [JsonProperty("badges")]
        public int Badges { get; set; }

        [JsonProperty("credits")]
        public int Credits { get; set; }

        [JsonProperty("others")]
        public List<Others> Others { get; set; }

        [JsonProperty("shards")]
        public int Shards { get; set; }

        [JsonProperty("xp")]
        public int Xp { get; set; }
    }
    public class Others
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public UInt64 Value { get; set; }
    }

    public class Synergy
    {
        [JsonProperty("command")]
        public double Command { get; set; }

        [JsonProperty("engineering")]
        public double Engineering { get; set; }

        [JsonProperty("science")]
        public double Science { get; set; }

        public override string ToString()
        {
            return $"[Synergy] C: {Command} E: {Engineering} S: {Science}";
        }
    }
    public partial class Trait
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("levels")]
        public List<Level> Levels { get; set; }

        [JsonProperty("tier")]
        public long Tier { get; set; }

        public override string ToString()
        {
            return $"[Trait] Name: {Name} | Levels: {Levels.Count}";
        }
    }
    public partial class Level
    {
        [JsonProperty("level")]
        public long LevelLevel { get; set; }

        [JsonProperty("trait_xp")]
        public long TraitXp { get; set; }

        public override string ToString()
        {
            return $"Level: {LevelLevel} | Trait XP: {TraitXp}";
        }
    }

}
