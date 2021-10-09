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

string folder = @"STFCCommunity-data.git\";
var officerList = MannSTFCTools.Util<Officer.JsonOfficer>.GetListFromJsonFolder(folder + "officers");
var shipList = MannSTFCTools.Util<Ship.JsonShip>.GetListFromJsonFolder(folder + "ships");


//foreach (Officer.JsonOfficer officer in officerList)
//{
//    if (offClassDictionary.TryGetValue(officer.Class.ToLower(), out _) == false)
//    {
//        offClassDictionary.Add(officer.Class.ToLower(), officer.Class);
//    }

//    if (offFactionDictionary.TryGetValue(officer.Faction.ToLower(), out _) == false)
//    {
//        offFactionDictionary.Add(officer.Faction.ToLower(), officer.Faction);
//    }

//    if (offGroupDictionary.TryGetValue(officer.Group.ToLower(), out _) == false)
//    {
//        offGroupDictionary.Add(officer.Group.ToLower(), officer.Group);
//    }

//    if (offNameDictionary.TryGetValue(officer.OfficerName.ToLower(), out _) == false)
//    {
//        offNameDictionary.Add(officer.OfficerName.ToLower(), officer.OfficerName);
//    }

//    if (offRarityDictionary.TryGetValue(officer.Rarity.ToLower(), out _) == false)
//    {
//        offRarityDictionary.Add(officer.Rarity.ToLower(), officer.Rarity);
//    }
//}

Console.WriteLine("Fully loaded");
