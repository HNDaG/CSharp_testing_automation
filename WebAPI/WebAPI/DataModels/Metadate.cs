using Newtonsoft.Json;
using System;

namespace WebAPI.DataModels
{
    public class Metadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("path_lower")]
        public string PathLower { get; set; }
        [JsonProperty("path_display")]
        public string PathDisplay { get; set; }

        public void Representation()
        {
            Console.WriteLine($"Name = {Name}\nID = {Id}\nPath_lower = {PathLower}\nPath_display = {PathDisplay}\n");
        }
    }
}