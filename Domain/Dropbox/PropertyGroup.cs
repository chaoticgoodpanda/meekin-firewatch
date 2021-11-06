using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Dropbox
{
    public class PropertyGroup
    {
        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }

        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }
    }
}