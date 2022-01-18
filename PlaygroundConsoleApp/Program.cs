using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using STFCLibrary.Util;
using STFCLibrary.Sqlite;
using static STFCLibrary.JsonClasses.Officer;
using System.IO.Compression;
using System.Text;

StfcLibDbContext db = new StfcLibDbContext();

Dictionary<string, string> classDictionary = new Dictionary<string, string>();
Dictionary<string, string> factionDictionary = new Dictionary<string, string>();
Dictionary<string, string> offGroupDictionary = new Dictionary<string, string>();
Dictionary<string, string> offNameDictionary = new Dictionary<string, string>();
Dictionary<string, string> rarityDictionary = new Dictionary<string, string>();

string folder = @"STFCCommunity-data.git\";
var officerList = JsonHelper<STFCLibrary.JsonClasses.Officer.JsonOfficer>.GetListFromJsonFolder(folder + "officers");

//Foo

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

static string GenerateShortString(List<JsonOfficer> officers)
{
    Random rnd = new Random();
    string returnString = "v0.1;";
    foreach(var officer in officers)
    {
        int hasOfficer = rnd.Next(0, 2);
        returnString += officer.OfficerName + "-" + hasOfficer.ToString() + ";";
    }

    return returnString;
}

//static void DoStuff()
//{
//    List<OffJson> output = new List<OffJson>();

//    foreach (var o in officerList)
//    {
//        classDictionary.TryAdd(o.Class.ToLower(), o.Class);
//        factionDictionary.TryAdd(o.Faction.ToLower(), o.Faction);
//        offGroupDictionary.TryAdd(o.Group.ToLower(), o.Group);

//        //output.Add(new OffJson() { Name = o.OfficerName, CapAbility = o.AbilityInfo.CaptainManeuver.Bonus + "~~~~" + o.AbilityInfo.CaptainManeuver.Buff, OffAbility = o.AbilityInfo.OfficerAbility.Bonus + "~~~~" + o.AbilityInfo.OfficerAbility.Buff, Keywords = "" });

//    }

//    string jsonData = File.ReadAllText("off.json") ?? throw new Exception($"Trouble with file, no data? Filename: off.json");
//    List<OffJson> items = JsonConvert.DeserializeObject<List<OffJson>>(jsonData) ?? throw new Exception($"Item is empty. Perhaps this is empty? JSON Data: '{jsonData}'");
//    Dictionary<string, keywordJson> keywordDict = new Dictionary<string, keywordJson>();

//    foreach (var x in items)
//    {
//        foreach (var kw in x.KeywordList)
//        {
//            keywordJson val;
//            if (keywordDict.TryGetValue(kw, out val))
//            {
//                val.Officers.Add(x.Name);
//            }
//            else
//            {
//                val = new keywordJson();
//                val.Officers.Add(x.Name);
//                val.Keyword = kw;

//                keywordDict.Add(kw, val);
//            }
//        }
//    }


//    JsonSerializer serializer = new JsonSerializer();
//    serializer.Formatting = Formatting.Indented;
//    using (StreamWriter sw = new StreamWriter(@"kw.json"))
//    using (JsonWriter writer = new JsonTextWriter(sw))
//    {
//        serializer.Serialize(writer, keywordDict);
//    }

//    //WriteGroup("Classes", classDictionary);
//    //WriteGroup("Factions", factionDictionary);
//    //WriteGroup("Groups", offGroupDictionary);
//}


class OffJson
{
    [JsonProperty("Officer")]
    public string Name { get; set; }

    [JsonProperty("Keywords")]
    public string Keywords { get; set; } = String.Empty;

    [JsonProperty("Cap")]
    public string CapAbility { get; set; }
    [JsonProperty("Off")]
    public string OffAbility { get; set; }

    public List<string> KeywordList { get
        {
            return Keywords.Split(';').ToList();
        } 
    }
}

class keywordJson
{
    [JsonProperty("Keyword")]
    public string Keyword { get; set; } = string.Empty;
    [JsonProperty("Officers")]
    public List<string> Officers { get; set; } = new List<string>();

    [JsonIgnore]
    public string AllOfficers { 
        get
        {
            return String.Join(',', Officers.OrderBy(x => x));
        } 
    }
}