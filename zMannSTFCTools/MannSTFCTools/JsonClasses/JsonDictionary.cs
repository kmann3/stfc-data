using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannSTFCTools.JsonClasses
{
    public class Entry
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }
        [JsonProperty("example")]
        public string Example { get; set; }
    }

    public class Dictionary
    {
        [JsonProperty("dictionary")]
        public List<Entry> Dict { get; set; }
    }
}
