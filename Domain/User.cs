using System.Collections.Generic;
using Domain.Facebook;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Organization { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        
        // users can have a many-to-many relationship with reports
        public ICollection<ReportReporter> Reports { get; set; }
        
        // users can have a many-to-many relationship with posts
        // e.g., users who think this post is an issue
        public ICollection<PostFollower> Posts { get; set; }
    }
}