using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Facebook
{
    public class Root
    {
        [Key]
        public Guid RootId { get; set; }
        
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

}