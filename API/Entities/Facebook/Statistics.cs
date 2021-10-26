using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Statistics
    {
        public int Id { get; set; }
        
        [JsonPropertyName("actual")]
        public Actual Actual { get; set; }

        [JsonPropertyName("expected")]
        public Expected Expected { get; set; }
    }
}