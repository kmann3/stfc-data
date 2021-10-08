using MannSTFCTools.JsonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Dictionary<string, string> offClassDictionary = new Dictionary<string, string>();
Dictionary<string, string> offFactionDictionary = new Dictionary<string, string>();
Dictionary<string, string> offGroupDictionary = new Dictionary<string, string>();
Dictionary<string, string> offNameDictionary = new Dictionary<string, string>();
Dictionary<string, string> offRarityDictionary = new Dictionary<string, string>();


var officerList = GetOfficerList();


foreach (JsonOfficer officer in officerList)
{
    if (offClassDictionary.TryGetValue(officer.Class.ToLower(), out _) == false)
    {
        offClassDictionary.Add(officer.Class.ToLower(), officer.Class);
    }

    if (offFactionDictionary.TryGetValue(officer.Faction.ToLower(), out _) == false)
    {
        offFactionDictionary.Add(officer.Faction.ToLower(), officer.Faction);
    }

    if (offGroupDictionary.TryGetValue(officer.Group.ToLower(), out _) == false)
    {
        offGroupDictionary.Add(officer.Group.ToLower(), officer.Group);
    }

    if (offNameDictionary.TryGetValue(officer.OfficerName.ToLower(), out _) == false)
    {
        offNameDictionary.Add(officer.OfficerName.ToLower(), officer.OfficerName);
    }

    if (offRarityDictionary.TryGetValue(officer.Rarity.ToLower(), out _) == false)
    {
        offRarityDictionary.Add(officer.Rarity.ToLower(), officer.Rarity);
    }
}

Console.WriteLine("Fully loaded");



static List<JsonOfficer> GetOfficerList()
{
    List<JsonOfficer> officerList = new();

    foreach (string f in Directory.GetFiles(@"STFCCommunity-data.git\officers"))
    {

        Console.WriteLine($"Loading '{f}");
        string jsonData = File.ReadAllText(f) ?? throw new Exception($"Trouble with file, no data? Filename: {f}");
        JsonOfficer officer = JsonConvert.DeserializeObject<JsonOfficer>(jsonData)?? throw new Exception($"Officer is empty. Perhaps this is empty? JSON Data: '{jsonData}'");

        // sanity check
        string offName = officer.OfficerName ?? throw new Exception($"Trouble with file, no data? Filename: {jsonData}");

        officerList.Add(officer);
    }

    return officerList;

}