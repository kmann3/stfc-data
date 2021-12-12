using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MannSTFCTools.JsonClasses
{
    /// <summary>
    /// Excel formula: ="["&CHAR(34)&"officer_name"&CHAR(34)&":"&CHAR(34)&A2&CHAR(34)&","&CHAR(34)&"tags"&CHAR(34)&": ["&CHAR(34)&SUBSTITUTE(D2,",",CHAR(34)&","&
    /// A1 = Officer Name
    /// A2 = Captain Manuever
    /// A3 = Officer Ability
    /// A4 = Tags (example: foo, bar, baz)
    /// A5 = Formula to concat a1-a4
    /// A6 = CLEAN(A5) // for copy and paste reasons, otherwise you end up with a LOT of extra quotes making JSON displeased
    /// </summary>
    class JsonOfficerTags
    {
        [JsonProperty("officer_name")]
        public string OfficerName { get; set; } = String.Empty;

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new();
    }
}
