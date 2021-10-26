using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Result
    {
        public int Id { get; set; }
        
        [JsonPropertyName("posts")]
        public List<Post> Posts { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
    
}