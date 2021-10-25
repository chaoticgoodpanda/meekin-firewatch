using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Dropbox
{
    public class Entry
    {
        [JsonPropertyName(".tag")]
        public string Tag { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("client_modified")]
        public DateTime ClientModified { get; set; }

        [JsonPropertyName("server_modified")]
        public DateTime ServerModified { get; set; }

        [JsonPropertyName("rev")]
        public string Rev { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("path_lower")]
        public string PathLower { get; set; }

        [JsonPropertyName("path_display")]
        public string PathDisplay { get; set; }

        [JsonPropertyName("sharing_info")]
        public SharingInfo SharingInfo { get; set; }

        [JsonPropertyName("is_downloadable")]
        public bool IsDownloadable { get; set; }

        [JsonPropertyName("property_groups")]
        public List<PropertyGroup> PropertyGroups { get; set; }

        [JsonPropertyName("has_explicit_shared_members")]
        public bool HasExplicitSharedMembers { get; set; }

        [JsonPropertyName("content_hash")]
        public string ContentHash { get; set; }

        [JsonPropertyName("file_lock_info")]
        public FileLockInfo FileLockInfo { get; set; }
    }
}