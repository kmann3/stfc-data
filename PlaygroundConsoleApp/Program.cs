using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using STFCLibrary.Util;
using STFCLibrary.Sqlite;

StfcLibDbContext db = new StfcLibDbContext();

Dictionary<string, string> classDictionary = new Dictionary<string, string>();
Dictionary<string, string> factionDictionary = new Dictionary<string, string>();
Dictionary<string, string> offGroupDictionary = new Dictionary<string, string>();
Dictionary<string, string> offNameDictionary = new Dictionary<string, string>();
Dictionary<string, string> rarityDictionary = new Dictionary<string, string>();

string folder = @"STFCCommunity-data.git\";
var officerList = JsonHelper<STFCLibrary.JsonClasses.Officer.JsonOfficer>.GetListFromJsonFolder(folder + "officers");

// Generate Lookups

List<OffJson> output = new List<OffJson>();

foreach (var o in officerList)
{
    classDictionary.TryAdd(o.Class.ToLower(), o.Class);
    factionDictionary.TryAdd(o.Faction.ToLower(), o.Faction);
    offGroupDictionary.TryAdd(o.Group.ToLower(), o.Group);

    output.Add(new OffJson() { Name = o.OfficerName, CapAbility = o.AbilityInfo.CaptainManeuver.Bonus + "~~~~" + o.AbilityInfo.CaptainManeuver.Buff, OffAbility = o.AbilityInfo.OfficerAbility.Bonus + "~~~~" + o.AbilityInfo.OfficerAbility.Buff, Keywords = "" });

}

JsonSerializer serializer = new JsonSerializer();
serializer.Formatting = Formatting.Indented;
using (StreamWriter sw = new StreamWriter(@"off.json"))
using (JsonWriter writer = new JsonTextWriter(sw))
{
    serializer.Serialize(writer, output);
    // {"ExpiryDate":new Date(1230375600000),"Price":0}
}

//WriteGroup("Classes", classDictionary);
//WriteGroup("Factions", factionDictionary);
//WriteGroup("Groups", offGroupDictionary);

Console.WriteLine("~~~~~~~~~~~~~~~~");
Console.WriteLine("Fully loaded");

static void WriteGroup(string name, Dictionary<string, string> group)
{
    Console.WriteLine();
    Console.WriteLine($"[{name}]");
    Console.WriteLine("-----------");
    foreach (var g in group.Values.OrderBy(x => x))
    {
        //2605 = *
        //00a0 = (space)
        Console.WriteLine(g.Replace("\u2605", "*"));
    }
}


class OffJson
{
    [JsonProperty("Officer")]
    public string Name { get; set; }

    [JsonProperty("Keywords")]
    public string Keywords { get; set; } = String.Empty;

    public List<string> KeywordList { get
        {
            return Keywords.Split(';').ToList();
        } 
    }
}
