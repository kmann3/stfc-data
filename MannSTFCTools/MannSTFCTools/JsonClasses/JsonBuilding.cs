using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannSTFCTools.JsonClasses
{
    public class Building
    {
        public class Bonus1
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("percentage")]
            public bool Percentage { get; set; }
        }

        public class Bonuses
        {
            [JsonProperty("bonus1")]
            public Bonus1 Bonus1 { get; set; }
        }

        public class Material
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("grade")]
            public int Grade { get; set; }

            [JsonProperty("rarity")]
            public string Rarity { get; set; }

            [JsonProperty("value")]
            public int Value { get; set; }
        }

        public class Resource
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public object Value { get; set; }
        }

        public class BuildCosts
        {
            [JsonProperty("materials")]
            public List<Material> Materials { get; set; }

            [JsonProperty("others")]
            public List<object> Others { get; set; }

            [JsonProperty("resources")]
            public List<Resource> Resources { get; set; }
        }

        public class Requirement
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("level")]
            public int Level { get; set; }
        }

        public class Reward
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public int Value { get; set; }
        }

        public class Level
        {
            [JsonProperty("bonuses")]
            public Bonuses Bonuses { get; set; }

            [JsonProperty("build_costs")]
            public BuildCosts BuildCosts { get; set; }

            [JsonProperty("build_time")]
            public int BuildTime { get; set; }

            [JsonProperty("increased_power")]
            public int IncreasedPower { get; set; }

            [JsonProperty("level")]
            public int LevelLevel { get; set; }

            [JsonProperty("requirements")]
            public List<Requirement> Requirements { get; set; }

            [JsonProperty("rewards")]
            public List<Reward> Rewards { get; set; }
        }

        public class JsonBuilding
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("bonuses")]
            public Bonuses Bonuses { get; set; }

            [JsonProperty("building_name")]
            public string BuildingName { get; set; }

            [JsonProperty("levels")]
            public List<Level> Levels { get; set; }
        }


    }
}
