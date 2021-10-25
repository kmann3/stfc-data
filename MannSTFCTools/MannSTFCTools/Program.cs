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
Dictionary<string, string> resourceDictionary = new Dictionary<string, string>();
Dictionary<string, string> materialDictionary = new Dictionary<string, string>();
Dictionary<string, string> partsDictionary = new Dictionary<string, string>();

string folder = @"STFCCommunity-data.git\";
var officerList = MannSTFCTools.JsonHelper<Officer.JsonOfficer>.GetListFromJsonFolder(folder + "officers");
var shipList = MannSTFCTools.JsonHelper<Ship.JsonShip>.GetListFromJsonFolder(folder + "ships");
//var buildingList = MannSTFCTools.JsonHelper<Building.JsonBuilding>.GetListFromJsonFolder(folder + "buildings");


foreach (var o in officerList)
{
    classDictionary.TryAdd(o.Class.ToLower(), o.Class);
    factionDictionary.TryAdd(o.Faction.ToLower(), o.Faction);
    offGroupDictionary.TryAdd(o.Group.ToLower(), o.Group);

}

foreach(var ship in shipList)
{
    foreach(var tier in ship.Tiers)
    {
        foreach(var component in tier.Components)
        {
            foreach (var resource in component.BuildCost.Resources)
            {
                resourceDictionary.TryAdd(resource.Type, resource.Type);
            }

            foreach (var material in component.BuildCost.Materials)
            {
                materialDictionary.TryAdd(material.Type, material.Type);
            }

            foreach (var part in component.BuildCost.Others)
            {
                partsDictionary.TryAdd(part.Type, part.Type);
            }

            
        }
    }
}


WriteGroup("Classes", classDictionary);
WriteGroup("Factions", factionDictionary);
WriteGroup("Groups", offGroupDictionary);
WriteGroup("Resources", resourceDictionary);
WriteGroup("Materials", materialDictionary);
WriteGroup("Parts", partsDictionary);

Console.WriteLine("~~~~~~~~~~~~~~~~");
Console.WriteLine("Fully loaded");

static void WriteGroup(string name, Dictionary<string, string> group)
{
    Console.WriteLine();
    Console.WriteLine($"[{name}]");
    Console.WriteLine("-----------");
    foreach (var g in group.Values.OrderBy(x => x))
    {
        Console.WriteLine(g.Replace("\u2605", "*"));
    }
}