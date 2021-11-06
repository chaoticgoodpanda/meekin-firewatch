using System.Text.Json.Serialization;

namespace Domain.Facebook
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