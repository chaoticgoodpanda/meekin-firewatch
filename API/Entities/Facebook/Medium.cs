using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Medium
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("full")]
        public string Full { get; set; }
    }

}