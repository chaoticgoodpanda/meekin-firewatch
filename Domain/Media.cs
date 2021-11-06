using System;

namespace Domain
{
    public class Media
    {
        public int Id { get; set; }
        public long? PostId { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Full { get; set; }
        public DateTime? Accesstime { get; set; }
    }
}