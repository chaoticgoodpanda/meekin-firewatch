using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Statistics
    {
        [JsonPropertyName("actual")]
        public Actual Actual { get; set; }

        [JsonPropertyName("expected")]
        public Expected Expected { get; set; }
    }
}