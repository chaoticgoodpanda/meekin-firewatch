using System;

namespace Domain.Facebook
{
    public class ReportReporter
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid ReportId { get; set; }
        public PostLabeling Report { get; set; }
        // boolean for the original author of the report
        public bool IsAuthor { get; set; }
    }
}