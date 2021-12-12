using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using STFCLibrary.JsonClasses;
using STFCLibrary.Util;

//MannSTFCTools.Sqlite.StfcDbContext db = new MannSTFCTools.Sqlite.StfcDbContext();

Dictionary<string, string> classDictionary = new Dictionary<string, string>();
Dictionary<string, string> factionDictionary = new Dictionary<string, string>();
Dictionary<string, string> offGroupDictionary = new Dictionary<string, string>();
Dictionary<string, string> offNameDictionary = new Dictionary<string, string>();
Dictionary<string, string> rarityDictionary = new Dictionary<string, string>();

string folder = @"STFCCommunity-data.git\";
var officerList = JsonHelper<Officer.JsonOfficer>.GetListFromJsonFolder(folder + "officers");

foreach (var o in officerList)
{
    classDictionary.TryAdd(o.Class.ToLower(), o.Class);
    factionDictionary.TryAdd(o.Faction.ToLower(), o.Faction);
    offGroupDictionary.TryAdd(o.Group.ToLower(), o.Group);

}

WriteGroup("Classes", classDictionary);
WriteGroup("Factions", factionDictionary);
WriteGroup("Groups", offGroupDictionary);

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