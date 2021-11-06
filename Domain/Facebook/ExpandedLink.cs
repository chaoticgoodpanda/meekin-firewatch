using System.Text.Json.Serialization;

namespace Domain.Facebook
{
    public class ExpandedLink
    {
        public int Id { get; set; }
        
        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonPropertyName("expanded")]
        public string Expanded { get; set; }
    }
}