using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConsoleTools
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"D:\Programming\git\stfc-data.git\lookups.json";

            var foo = Lookups.GetLookupsFromFile(fileName);

            Console.WriteLine(foo.LastModified);
            int count = 0;
            foreach(string x in foo.Officers)
            {
                string name = x.Replace(" ", "-").Replace("'", "");
                string officerFileName = @"D:\Programming\git\stfc-data.git\officer-" + name + ".z.json";
                bool exists = System.IO.File.Exists(officerFileName);
                Console.WriteLine($"{x} : {exists} : {officerFileName}");
                if (!exists) continue;

                //Lookups returnValue = JsonConvert.DeserializeObject<Lookups>(File.ReadAllText(fileName));
                Officer o = JsonConvert.DeserializeObject<Officer>(File.ReadAllText(officerFileName));

                Console.WriteLine(o.Class);

                o.Faction = "";
                o.LastModified = DateTime.Now;

                o.Ranks["1"].ResourceCost = null;

                o.Ranks["5"].ResourceCost.Add(new ResourceCost()
                {
                    Count = 1,
                    Type = "Badge"
                });

                File.WriteAllText(officerFileName, JsonConvert.SerializeObject(o, Formatting.Indented));

                //officerFileName = "officer-" + name + ".z.json";
                //Officer o = new Officer();
                //o.Guid = Guid.NewGuid().ToString().ToUpper();
                //o.LastModified = DateTime.Now;
                //o.Name = x;
                //o.Type = "Officer";
                //o.Tags = new List<string>();
                //o.Tags.Add("TBI");
                //o.Class = "";
                //o.Description = "";
                //o.Group = "";
                //o.Rarity = "";
                //o.SynergyCommand = 0;
                //o.SynergyEngineering = 0;
                //o.SynergyScience = 0;
                //o.Ranks = new Dictionary<string, Rank>();
                //o.Ranks.Add("1", new Rank()
                //{
                //    ResourceCost = new System.Collections.Generic.List<ResourceCost>() { 
                //        new ResourceCost() {
                //    Type = "Independent Credits",
                //            Count = 0 } },
                //    ShardsRequired = 0
                //});
                //o.Ranks.Add("2", new Rank()
                //{
                //    ResourceCost = new System.Collections.Generic.List<ResourceCost>() { new ResourceCost() {
                //    Type = "Independent Credits", Count = 0 } },
                //    ShardsRequired = 0
                //});
                //o.Ranks.Add("3", new Rank()
                //{
                //    ResourceCost = new System.Collections.Generic.List<ResourceCost>() { new ResourceCost() {
                //    Type = "Independent Credits", Count = 0 } },
                //    ShardsRequired = 0
                //});
                //o.Ranks.Add("4", new Rank()
                //{
                //    ResourceCost = new System.Collections.Generic.List<ResourceCost>() { new ResourceCost() {
                //    Type = "Independent Credits", Count = 0 } },
                //    ShardsRequired = 0
                //});
                //o.Ranks.Add("5", new Rank()
                //{
                //    ResourceCost = new System.Collections.Generic.List<ResourceCost>() { new ResourceCost() {
                //    Type = "Independent Credits", Count = 0 } },
                //    ShardsRequired = 0
                //});

                //o.CaptainManeuver = new CaptainManeuver();
                //o.CaptainManeuver.Name = "";
                //o.CaptainManeuver.Description = "";

                //o.OfficerAbility = new OfficerAbility();
                //o.OfficerAbility.Name = "";
                //o.OfficerAbility.DescriptionRank1 = "";
                //o.OfficerAbility.DescriptionRank2 = "";
                //o.OfficerAbility.DescriptionRank3 = "";
                //o.OfficerAbility.DescriptionRank4 = "";
                //o.OfficerAbility.DescriptionRank5 = "";

                //o.ImageUrl = "images/officers/" + x.Replace(" ", "").Replace("'", "") + ".png";



                //File.WriteAllText(officerFileName, JsonConvert.SerializeObject(o, Formatting.Indented));
                //

            }
            Console.WriteLine("End " + count);
            Console.Read();
        }
    }
}
