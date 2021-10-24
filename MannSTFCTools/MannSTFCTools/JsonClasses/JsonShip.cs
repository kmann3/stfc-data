using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace MannSTFCTools.JsonClasses
{
    public class Ship
    {
        public class Blueprints
        {
            [JsonProperty("cost")]
            public int Cost { get; set; }

            [JsonProperty("quantity")]
            public int Quantity { get; set; }

            public override string ToString()
            {
                return $"Cost: {Cost} | Quantity: {Quantity}";
            }
        }

        public class Requirement
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("level")]
            public int Level { get; set; }
            public override string ToString()
            {
                return $"Name: {Name} | Level: {Level}";
            }
        }

        public class ScrapInfo
        {
            [JsonProperty("required_scrapyard_level")]
            public int RequiredScrapyardLevel { get; set; }

            [JsonProperty("scrappable")]
            public bool Scrappable { get; set; }

            public override string ToString()
            {
                return $"Yard Level: {RequiredScrapyardLevel} | Scrappable: {Scrappable}";
            }
        }

        public class ShipAbility
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("percentage")]
            public bool Percentage { get; set; }
        }

        public class WeaponsInfo
        {
            [JsonProperty("accuracy")]
            public int Accuracy { get; set; }

            [JsonProperty("armor_pierce")]
            public int ArmorPierce { get; set; }

            [JsonProperty("crit_chance")]
            public double CritChance { get; set; }

            [JsonProperty("crit_damage")]
            public double CritDamage { get; set; }

            [JsonProperty("firing_pattern")]
            public List<int> FiringPattern { get; set; }

            [JsonProperty("max_damage")]
            public int MaxDamage { get; set; }

            [JsonProperty("min_damage")]
            public int MinDamage { get; set; }

            [JsonProperty("shield_pierce")]
            public int ShieldPierce { get; set; }

            [JsonProperty("weapon_type")]
            public string WeaponType { get; set; }
        }

        public class CargoInfo
        {
            [JsonProperty("increased_cargo")]
            public int IncreasedCargo { get; set; }

            [JsonProperty("increased_protected_cargo")]
            public int IncreasedProtectedCargo { get; set; }

            [JsonProperty("ship_increased_cargo")]
            public int ShipIncreasedCargo { get; set; }

            [JsonProperty("ship_increased_protected_cargo")]
            public int ShipIncreasedProtectedCargo { get; set; }
        }

        public class WarpInfo
        {
            [JsonProperty("warp_distance")]
            public int WarpDistance { get; set; }

            [JsonProperty("warp_speed")]
            public double WarpSpeed { get; set; }
        }

        public class ImpulseInfo
        {
            [JsonProperty("dodge")]
            public int Dodge { get; set; }

            [JsonProperty("impulse_speed")]
            public int ImpulseSpeed { get; set; }
        }

        public class ShieldInfo
        {
            [JsonProperty("shield_deflection")]
            public int ShieldDeflection { get; set; }

            [JsonProperty("shield_health")]
            public int ShieldHealth { get; set; }
        }

        public class MiningLaserInfo
        {
            [JsonProperty("mining_bonus")]
            public int MiningBonus { get; set; }
        }

        public class AdditionalInfo
        {
            [JsonProperty("weapons_info")]
            public WeaponsInfo WeaponsInfo { get; set; }

            [JsonProperty("cargo_info")]
            public CargoInfo CargoInfo { get; set; }

            [JsonProperty("warp_info")]
            public WarpInfo WarpInfo { get; set; }

            [JsonProperty("impulse_info")]
            public ImpulseInfo ImpulseInfo { get; set; }

            [JsonProperty("shield_info")]
            public ShieldInfo ShieldInfo { get; set; }

            [JsonProperty("mining_laser_info")]
            public MiningLaserInfo MiningLaserInfo { get; set; }
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
            public UInt64 Value { get; set; }
        }

        public class Others
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public int Value { get; set; }
        }

        public class Resource
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public UInt64 Value { get; set; }
        }

        public class BuildCost
        {
            [JsonProperty("materials")]
            public List<Material> Materials { get; set; }

            [JsonProperty("others")]
            public List<Others> Others { get; set; }

            [JsonProperty("resources")]
            public List<Resource> Resources { get; set; }
        }

        public class RepairCost
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public int Value { get; set; }
        }

        public class Component
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("additional_info")]
            public AdditionalInfo AdditionalInfo { get; set; }

            [JsonProperty("build_cost")]
            public BuildCost BuildCost { get; set; }

            [JsonProperty("img_url")]
            public string ImgUrl { get; set; }

            [JsonProperty("quantity")]
            public int Quantity { get; set; }

            [JsonProperty("repair_cost")]
            public List<RepairCost> RepairCost { get; set; }
        }

        public class InitialBuildCost
        {
            [JsonProperty("materials")]
            public List<Material> Materials { get; set; }

            [JsonProperty("others")]
            public List<Others> Others { get; set; }

            [JsonProperty("resources")]
            public List<Resource> Resources { get; set; }
        }

        public class Reward
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public int Value { get; set; }

            [JsonProperty("grade")]
            public int? Grade { get; set; }

            [JsonProperty("rarity")]
            public string Rarity { get; set; }
        }

        public class ScrapDetails
        {
            [JsonProperty("rewards")]
            public List<Reward> Rewards { get; set; }

            [JsonProperty("scrap_time")]
            public int ScrapTime { get; set; }
        }

        public class Level
        {
            [JsonProperty("ability_bonus")]
            public double AbilityBonus { get; set; }

            [JsonProperty("additional_officer_slot")]
            public bool AdditionalOfficerSlot { get; set; }

            [JsonProperty("level")]
            public int zLevel { get; set; }

            [JsonProperty("scrap_details")]
            public ScrapDetails ScrapDetails { get; set; }

            [JsonProperty("ship_xp")]
            public int ShipXp { get; set; }
        }

        public class Tier
        {
            [JsonProperty("build_time")]
            public int BuildTime { get; set; }

            [JsonProperty("components")]
            public List<Component> Components { get; set; }

            [JsonProperty("initial_build_cost")]
            public InitialBuildCost InitialBuildCost { get; set; }

            [JsonProperty("levels")]
            public List<Level> Levels { get; set; }

            [JsonProperty("repair_time")]
            public int RepairTime { get; set; }

            [JsonProperty("tier")]
            public int zTier { get; set; }
        }

        public class JsonShip : JsonHelper<JsonShip>.IJsonBase
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("blueprints")]
            public Blueprints Blueprints { get; set; }

            [JsonProperty("faction")]
            public string Faction { get; set; }

            [JsonProperty("grade")]
            public int Grade { get; set; }

            [JsonProperty("img_url")]
            public string ImgUrl { get; set; }

            [JsonProperty("rarity")]
            public string Rarity { get; set; }

            [JsonProperty("requirements")]
            public List<Requirement> Requirements { get; set; }

            [JsonProperty("scrap_info")]
            public ScrapInfo ScrapInfo { get; set; }

            [JsonProperty("ship_ability")]
            public ShipAbility ShipAbility { get; set; }

            [JsonProperty("ship_class")]
            public string ShipClass { get; set; }

            [JsonProperty("ship_name")]
            public string ShipName { get; set; }

            [JsonProperty("tiers")]
            public List<Tier> Tiers { get; set; }
            public string Name => this.ShipName;

            public override string ToString()
            {
                return this.Name;
            }

        }
    }
}
