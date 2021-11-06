using System.Text.Json.Serialization;

namespace Domain.Dropbox
{
    public class Field
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}