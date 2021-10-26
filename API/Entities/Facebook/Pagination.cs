using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Pagination
    {
        public int Id { get; set; }
        
        [JsonPropertyName("nextPage")]
        public string NextPage { get; set; }
    }

}