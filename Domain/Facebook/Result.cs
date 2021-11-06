using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Facebook
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