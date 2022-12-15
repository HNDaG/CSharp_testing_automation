using Newtonsoft.Json;

namespace WebAPI.DataModels
{
    public class Base
    {
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;
    }
}