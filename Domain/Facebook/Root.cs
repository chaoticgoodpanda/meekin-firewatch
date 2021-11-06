using System.Text.Json.Serialization;

namespace Domain.Facebook
{
    public class Root
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

}