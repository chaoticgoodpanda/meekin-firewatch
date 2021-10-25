using System;
using System.Text.Json.Serialization;

namespace API.Dropbox
{
    public class FileLockInfo
    {
        [JsonPropertyName("is_lockholder")]
        public bool IsLockholder { get; set; }

        [JsonPropertyName("lockholder_name")]
        public string LockholderName { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
    }
}