using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Application.Profiles;
using Domain.Facebook;

namespace Application.Events
{
    public class PostDto
    {
        [Key]
        public Guid GuidId { get; set; }
        
        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("expandedLinks")]
        public List<ExpandedLink> ExpandedLinks { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("postUrl")]
        public string PostUrl { get; set; }

        [JsonPropertyName("subscriberCount")]
        public int SubscriberCount { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("media")]
        public List<Medium> Media { get; set; }

        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }

        [JsonPropertyName("account")]
        public Account Account { get; set; }

        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }

        [JsonPropertyName("legacyId")]
        public int? LegacyId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("videoLengthMS")]
        public int? VideoLengthMS { get; set; }
        
        public string PosterUsername { get; set; }
        
        public ICollection<Profile> Posters { get; set; }
    }
}