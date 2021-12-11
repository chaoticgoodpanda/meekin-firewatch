using System;

namespace Domain.Facebook
{
    public class PostFollower
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        // boolean for first poster of the post
        public bool IsPoster { get; set; }
    }
}