using System.Text.Json.Serialization;

namespace API.Facebook
{
    public class Account
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("handle")]
        public string Handle { get; set; }

        [JsonPropertyName("profileImage")]
        public string ProfileImage { get; set; }

        [JsonPropertyName("subscriberCount")]
        public int SubscriberCount { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }

        [JsonPropertyName("pageAdminTopCountry")]
        public string PageAdminTopCountry { get; set; }

        [JsonPropertyName("pageDescription")]
        public string PageDescription { get; set; }

        [JsonPropertyName("pageCreatedDate")]
        public string PageCreatedDate { get; set; }

        [JsonPropertyName("pageCategory")]
        public string PageCategory { get; set; }

        [JsonPropertyName("verified")]
        public bool Verified { get; set; }
    }
}