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
        static void Main()
        {
            string fileName = @"D:\Programming\git\stfc-data.git\lookups.json";

            var foo = Lookups.GetLookupsFromFile(fileName);

            Console.WriteLine(foo.LastModified);
            int count = 0;
            foreach(string x in foo.Officers)
            {
                count++;
                string name = x.Replace(" ", "-").Replace("'", "");
                string officerFileName = @"D:\Programming\git\stfc-data.git\officer-" + name + ".z.json";
                bool exists = System.IO.File.Exists(officerFileName);
                Console.WriteLine($"{x} : {exists} : {officerFileName}");
                if (!exists)
                {
                    officerFileName = officerFileName.Replace(".z.json", ".json");
                    if (!File.Exists(officerFileName)) continue;
                }

                //Lookups returnValue = JsonConvert.DeserializeObject<Lookups>(File.ReadAllText(fileName));
                Officer o = JsonConvert.DeserializeObject<Officer>(File.ReadAllText(officerFileName));
                

                Console.WriteLine(o.Name);
                o.Id = count;
                if (String.IsNullOrEmpty(o.Group))
                {
                    o.Ranks["1"].Xp = 0;
                    o.Ranks["2"].Xp = 0;
                    o.Ranks["3"].Xp = 0;
                    o.Ranks["4"].Xp = 0;
                    o.Ranks["5"].Xp = 0;

                    o.Ranks["1"].ResourceCost = null;

                    o.Ranks["4"].ResourceCost[0].Type = " Credits";
                    if (o.Ranks["4"].ResourceCost.Count == 2)
                    {
                        o.Ranks["4"].ResourceCost[1].Type = " Badges";
                        o.Ranks["4"].ResourceCost[1].Count = 1;
                    } else
                    {
                        o.Ranks["4"].ResourceCost.Add(new ResourceCost()
                        {
                            Count = 1,
                            Type = " Badges"
                        });
                    }

                    o.Ranks["5"].ResourceCost[0].Type = " Credits";
                    o.Ranks["5"].ResourceCost[1].Type = " Badges";
                    o.Ranks["5"].ResourceCost[1].Count = 2;


                    o.LastModified = DateTime.Now.ToString("yyyy-MM-ddTHH:MM:ss-05:00");

                    File.WriteAllText(officerFileName, JsonConvert.SerializeObject(o, Formatting.Indented));
                } else
                {
                    o.Id = count;
                    o.Ranks["1"].Xp = 0;
                    o.Ranks["1"].ResourceCost = null;
                    o.LastModified = DateTime.Now.ToString("yyyy-MM-ddTHH:MM:ss-05:00");
                    
                    
                    File.WriteAllText(officerFileName, JsonConvert.SerializeObject(o, Formatting.Indented));
                }

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
