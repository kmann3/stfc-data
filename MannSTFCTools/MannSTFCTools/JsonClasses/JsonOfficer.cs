using Newtonsoft.Json;
using System.Collections.Generic;

namespace MannSTFCTools.JsonClasses
{
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
    }

    public partial class Buff
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class AbilityInfo
    {
        [JsonProperty("captain_maneuver")]
        public CaptainManeuver CaptainManeuver { get; set; }

        [JsonProperty("officer_ability")]
        public OfficerAbility OfficerAbility { get; set; }
    }

    public class Others
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("value")]
        public long Value { get; set; }
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
    }

    public class Synergy
    {
        [JsonProperty("command")]
        public double Command { get; set; }

        [JsonProperty("engineering")]
        public double Engineering { get; set; }

        [JsonProperty("science")]
        public double Science { get; set; }
    }

    public class JsonOfficer
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

        public override string ToString()
        {
            return OfficerName;
        }
    }


}
