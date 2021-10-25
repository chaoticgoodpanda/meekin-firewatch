using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class ExpandedLink
    {
        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonPropertyName("expanded")]
        public string Expanded { get; set; }
    }
}