using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Pagination
    {
        [JsonPropertyName("nextPage")]
        public string NextPage { get; set; }
    }

}