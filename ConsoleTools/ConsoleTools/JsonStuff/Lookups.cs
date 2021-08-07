namespace ConsoleTools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Lookups
    {
        [JsonProperty("lastModified")]
        public string LastModified { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("systems")]
        public List<string> Systems { get; set; }

        [JsonProperty("rarities")]
        public List<String> Rarities { get; set; }

        [JsonProperty("classes")]
        public List<String> Classes { get; set; }

        [JsonProperty("factions")]
        public List<string> Factions { get; set; }

        [JsonProperty("officer-groups")]
        public List<string> OfficerGroups { get; set; }

        [JsonProperty("officers")]
        public List<string> Officers { get; set; }

        [JsonProperty("aquisitions")]
        public List<string> Aquisitions { get; set; }

        [JsonProperty("ship-types")]
        public List<string> ShipTypes { get; set; }

        [JsonProperty("ships")]
        public List<string> Ships { get; set; }

        [JsonProperty("reputations")]
        public List<string> Reputations { get; set; }

        [JsonProperty("currencies")]
        public List<string> Currencies { get; set; }

        public static Lookups GetLookupsFromFile(string fileName)
        {
            //myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            Lookups returnValue = JsonConvert.DeserializeObject<Lookups>(File.ReadAllText(fileName));
            return returnValue;
        }
    }
}
