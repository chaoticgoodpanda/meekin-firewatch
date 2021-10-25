using System.Text.Json.Serialization;

namespace API.Dropbox
{
    public class SharingInfo
    {
        [JsonPropertyName("read_only")]
        public bool ReadOnly { get; set; }

        [JsonPropertyName("parent_shared_folder_id")]
        public string ParentSharedFolderId { get; set; }

        [JsonPropertyName("modified_by")]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("traverse_only")]
        public bool? TraverseOnly { get; set; }

        [JsonPropertyName("no_access")]
        public bool? NoAccess { get; set; }
    }
}