using MannSTFCTools.JsonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

MannSTFCTools.Sqlite.StfcDbContext db = new MannSTFCTools.Sqlite.StfcDbContext();

Dictionary<string, string> classDictionary = new Dictionary<string, string>();
Dictionary<string, string> factionDictionary = new Dictionary<string, string>();
Dictionary<string, string> offGroupDictionary = new Dictionary<string, string>();
Dictionary<string, string> offNameDictionary = new Dictionary<string, string>();
Dictionary<string, string> rarityDictionary = new Dictionary<string, string>();

string folder = @"STFCCommunity-data.git\";
var officerList = MannSTFCTools.JsonHelper<Officer.JsonOfficer>.GetListFromJsonFolder(folder + "officers");
var shipList = MannSTFCTools.JsonHelper<Ship.JsonShip>.GetListFromJsonFolder(folder + "ships");


foreach(var o in officerList)
{
    if (classDictionary.TryGetValue(o.Class.ToLower(), out _) == false)
    {
        classDictionary.Add(o.Class.ToLower(), o.Class);
    }

    if (factionDictionary.TryGetValue(o.Faction.ToLower(), out _) == false)
    {
        factionDictionary.Add(o.Faction.ToLower(), o.Faction);
    }

    if (offGroupDictionary.TryGetValue(o.Group.ToLower(), out _) == false)
    {
        offGroupDictionary.Add(o.Group.ToLower(), o.Group);
    }

}

Console.WriteLine();
Console.WriteLine("[Classes]");
Console.WriteLine("-----------");
foreach (var c in classDictionary.Values.OrderBy(x => x))
{
    Console.WriteLine(c);
}

Console.WriteLine();
Console.WriteLine("[Factions]");
Console.WriteLine("-----------");
foreach (var f in factionDictionary.Values.OrderBy(x => x))
{
    Console.WriteLine(f);
}

Console.WriteLine();
Console.WriteLine("[Groups]");
Console.WriteLine("-----------");
foreach (var g in offGroupDictionary.Values.OrderBy(x => x))
{
    Console.WriteLine(g);
}

Console.WriteLine("~~~~~~~~~~~~~~~~");
Console.WriteLine("Fully loaded");
