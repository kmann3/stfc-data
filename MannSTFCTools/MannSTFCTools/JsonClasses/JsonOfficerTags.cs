using Newtonsoft.Json;

namespace MannSTFCTools.JsonClasses
{
    class JsonOfficerTags
    {
        [JsonProperty("officer_name")]
        public string OfficerName { get; set; } = String.Empty;

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new();
    }
}
