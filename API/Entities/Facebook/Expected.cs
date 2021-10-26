using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Expected
    {
        public int Id { get; set; }
        
        [JsonPropertyName("likeCount")]
        public int LikeCount { get; set; }

        [JsonPropertyName("shareCount")]
        public int ShareCount { get; set; }

        [JsonPropertyName("commentCount")]
        public int CommentCount { get; set; }

        [JsonPropertyName("loveCount")]
        public int LoveCount { get; set; }

        [JsonPropertyName("wowCount")]
        public int WowCount { get; set; }

        [JsonPropertyName("hahaCount")]
        public int HahaCount { get; set; }

        [JsonPropertyName("sadCount")]
        public int SadCount { get; set; }

        [JsonPropertyName("angryCount")]
        public int AngryCount { get; set; }

        [JsonPropertyName("thankfulCount")]
        public int ThankfulCount { get; set; }

        [JsonPropertyName("careCount")]
        public int CareCount { get; set; }
    }

}