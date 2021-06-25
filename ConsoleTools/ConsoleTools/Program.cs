using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using StfcWeb.Data;
using StfcWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ConsoleTools
{
    class Program
    {
        public static List<OfficerJson> jsonList = new List<OfficerJson>();
        public static string stfcDirectory = @"D:\Programming\git\stfc-data\";
        public static string lookupFileName = stfcDirectory + @"lookups.json";
        public static Lookups lookupData = Lookups.GetLookupsFromFile(lookupFileName);
        static async Task Main()
        {
            LoadJsonList();
            
            using(ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                // Core tables that may reference lookups
                await dbContext.Database.ExecuteSqlRawAsync("DELETE [Officers]");

                // Lookups
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Classes]");
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Factions]");
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [News]");
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [OfficerRankResources]");
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Rarities]");
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Tags]");

                List<Class> classList = new List<Class>();
                Dictionary<string, int> classDictionary = new Dictionary<string, int>();
                List<Faction> factionList = new List<Faction>();
                Dictionary<string, int> factionDictionary = new Dictionary<string, int>();
                List<Tag> tagList = new List<Tag>();
                Dictionary<string, int> tagDictionary = new Dictionary<string, int>();

                foreach (string c in lookupData.Classes)
                {
                    Console.WriteLine($"Class: {c}");
                    classList.Add(new Class(c));
                }
                dbContext.Classes.AddRange(classList);


                foreach(string f in lookupData.Factions)
                {
                    Console.WriteLine($"Factions {f}");
                    factionList.Add(new Faction(f));
                }
                dbContext.Factions.AddRange(factionList);

                foreach(string t in lookupData.Tags)
                {
                    Console.WriteLine($"Tags: {t}");
                    tagList.Add(new Tag(t));
                }
                dbContext.Tags.AddRange(tagList);

                dbContext.SaveChanges();

                foreach(OfficerJson oj in jsonList)
                {
                    Officer newOfficer = new Officer();
                    newOfficer.Name = oj.Name;
                    newOfficer.ClassId = classDictionary[oj.Class];
                }

            }

            Console.WriteLine("Done.");
            Console.Read();
        }

        public static void LoadJsonList()
        {
            foreach (string officer in lookupData.Officers)
{
                string name = officer.Replace(" ", "-").Replace("'", "");
                string officerFileName = stfcDirectory + @"officer-z-" + name + ".json";
                string officerFileNameNoZ = stfcDirectory +  @"officer-" + name + ".json";
                bool exists = File.Exists(officerFileName);
                if (!exists)
                {
                    Debug.Assert(File.Exists(officerFileName) || File.Exists(officerFileNameNoZ));
                    officerFileName = officerFileName.Replace("-z-", "-");
                }

                jsonList.Add(JsonConvert.DeserializeObject<OfficerJson>(File.ReadAllText(officerFileName)));
            }
        }

        public static void DoThing()
        {
            string fileName = @"D:\Programming\git\stfc-data.git\lookups.json";

            var foo = Lookups.GetLookupsFromFile(fileName);

            Console.WriteLine(foo.LastModified);
            int count = 0;
            foreach (string x in foo.Officers)
            {
                count++;
                string name = x.Replace(" ", "-").Replace("'", "");
                string officerFileName = @"D:\Programming\git\stfc-data.git\officer-z-" + name + ".json";
                string officerFileNameNoZ = @"D:\Programming\git\stfc-data.git\officer-" + name + ".json";
                bool exists = System.IO.File.Exists(officerFileName);
                Console.WriteLine($"{x} : {exists} : {officerFileName}");
                if (!exists)
                {
                    Debug.Assert(File.Exists(officerFileName) || File.Exists(officerFileNameNoZ));
                    officerFileName = officerFileName.Replace("-z-", "-");
                }

                //Lookups returnValue = JsonConvert.DeserializeObject<Lookups>(File.ReadAllText(fileName));
                OfficerJson o = JsonConvert.DeserializeObject<OfficerJson>(File.ReadAllText(officerFileName));


                Console.WriteLine(o.Name);
                o.Id = count;
                o.SynergyCommand = 55;
                o.LastModified = DateTime.Now.ToString("yyyy-MM-ddTHH:MM:ss-05:00");
                int i = o.Ranks["1"].Xp;
                int a = o.Ranks["2"].Xp;
                int b = o.Ranks["3"].Xp;
                int c = o.Ranks["4"].Xp;
                int d = o.Ranks["5"].Xp;

                Console.WriteLine(i + a + b + c + d);
                //File.WriteAllText(officerFileName + ".tmp.json", JsonConvert.SerializeObject(o, Formatting.Indented));
                //if (count > 2) break;

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
            }
            Console.WriteLine("End " + count);
        }
    }
}
