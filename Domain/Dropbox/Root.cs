using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Dropbox
{
    public class Root
    {
        [JsonPropertyName("entries")]
        public List<Entry> Entries { get; set; }

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }
    }
}