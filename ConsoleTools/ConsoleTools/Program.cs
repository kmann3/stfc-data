using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using StfcWeb.Data;
using StfcWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

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
            DoThing();
            
            //using(ApplicationDbContext dbContext = new ApplicationDbContext())
            //{
            //    // Core tables that may reference lookups
            //    await dbContext.Database.ExecuteSqlRawAsync("DELETE [Officers]");

            //    // Lookups
            //    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Classes]");
            //    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Factions]");
            //    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [News]");
            //    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [OfficerRankResources]");
            //    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Rarities]");
            //    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Tags]");

            //    List<Class> classList = new List<Class>();
            //    Dictionary<string, int> classDictionary = new Dictionary<string, int>();
            //    List<Faction> factionList = new List<Faction>();
            //    Dictionary<string, int> factionDictionary = new Dictionary<string, int>();
            //    List<Tag> tagList = new List<Tag>();
            //    Dictionary<string, int> tagDictionary = new Dictionary<string, int>();

            //    foreach (string c in lookupData.Classes)
            //    {
            //        Console.WriteLine($"Class: {c}");
            //        classList.Add(new Class(c));
            //    }
            //    dbContext.Classes.AddRange(classList);


            //    foreach(string f in lookupData.Factions)
            //    {
            //        Console.WriteLine($"Factions {f}");
            //        factionList.Add(new Faction(f));
            //    }
            //    dbContext.Factions.AddRange(factionList);

            //    foreach(string t in lookupData.Tags)
            //    {
            //        Console.WriteLine($"Tags: {t}");
            //        tagList.Add(new Tag(t));
            //    }
            //    dbContext.Tags.AddRange(tagList);

            //    dbContext.SaveChanges();

            //    foreach(OfficerJson oj in jsonList)
            //    {
            //        Officer newOfficer = new Officer();
            //        newOfficer.Name = oj.Name;
            //        newOfficer.ClassId = classDictionary[oj.Class];
            //    }

            //}

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
            if(!File.Exists(lookupFileName))
            {
                Console.WriteLine("Lookups not found?");
                throw new FileNotFoundException();
            }

            Lookups foo = Lookups.GetLookupsFromFile(lookupFileName);

            Console.WriteLine(foo.LastModified);
            int count = 0;
            foreach (string x in foo.Officers.OrderBy(q => q)) // The orderby should just do a simple sort, and because we use the z to sort in Explorer, this should also work here
            {
                count++;
                string name = x.Replace(" ", "-").Replace("'", "");
                string officerFileName = $"{stfcDirectory}officer-" + name + ".json";
                bool exists = File.Exists(officerFileName);
                Console.WriteLine($"{x} : {exists} : {officerFileName}");
                if (!exists)
                {
                    Debug.Assert(File.Exists(officerFileName) || File.Exists(officerFileName.Replace("officer-", "officer-z-")));
                    officerFileName = officerFileName.Replace("officer-", "officer-z-");
                } else
                {
                    // For the sake of sanity, let's make a backup.
                    // We only care about work done, everything else can be scripted to be fixed somehow or another
                    File.Copy(officerFileName, officerFileName.Replace(".json", "") + "-BACKUP.json", true);
                }

                //Lookups returnValue = JsonConvert.DeserializeObject<Lookups>(File.ReadAllText(fileName));
                OfficerJson o = JsonConvert.DeserializeObject<OfficerJson>(File.ReadAllText(officerFileName));


                Console.WriteLine(o.Name);
                o.LastModified = DateTime.Now.ToString("yyyy-MM-ddTHH:MM:ss-05:00");

                // Things to do:
                // 1 Update Officer ability
                // 2 Add stats, for the moment, we will amke them all null

                // Let's work on Office Ability first
                o.OfficerAbility.DescriptionText = "";
                o.OfficerAbility.DescriptionValue1 = null;
                o.OfficerAbility.DescriptionValue2 = null;
                o.OfficerAbility.DescriptionValue3 = null;
                o.OfficerAbility.DescriptionValue4 = null;
                o.OfficerAbility.DescriptionValue5 = null;

                o.Stats = new Dictionary<string, Stat>();

                for(int i=1;i<=15;i++)
                {
                    o.Stats.Add(i.ToString(), new Stat() { Attack = null, Defense = null, Health = null });
                }


                File.WriteAllText(officerFileName, JsonConvert.SerializeObject(o, Formatting.Indented));
            }
            Console.WriteLine("End " + count);
        }
    }
}
