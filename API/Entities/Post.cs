using System;
using System.Collections.Generic;

namespace API
{
    public class Post
    {
        // Id for the Post in question allocated by MeekinF
        public Post(ICollection<PostLabeling> postLabeling)
        {
            PostLabeling = new HashSet<PostLabeling>();
        }

        public int Id { get; set; }
        
        // Facebook account id
        public int AccountId { get; set; }
        
        // Facebook account name
        public string AccountName { get; set; }

        // post content
        public string PostContent {get; set;}
        
        // Facebook profile image 
        public string ProfileImage { get; set; }
        
        // Which social media platform used (e.g. Facebook, Twitter, Reddit, Instagram)
        public string SocialMediaPlatform { get; set; }
        
        // id on social media platform -- long because tends to be longer than int max
        public long SocialMediaPlatformId { get; set; }
        
        // account type -- page, group, something else
        public string AccountType { get; set; }
        
        // country of the page
        public string AccountCountry { get; set; }
        
        // verified account
        public bool Verified { get; set; }
        
        // URL to the original post (may not still be on Facebook)
        public string PostUrl { get; set; }
        
        // Media URL to raw image/audio/video file in post, if any
        public string MediaUrl { get; set; }
        
        // text accompanying any image
        public string ImageText { get; set; }
        
        // The number of subscribers/followers a particular account has
        public long SubscriberCount { get; set; }

		// score -- Crowdtangle assigned score which looks like total engagements
		public double Score {get; set;}

        public string Message { get; set; }
        public DateTime? PostCreationTime { get; set; }
        public DateTime? CrowdtangleUpdateTime { get; set; }
        public DateTime? AccessTime { get; set; }
        public string ExternalLink { get; set; }
        public string LinkCaption { get; set; }
        public string LinkTitle { get; set; }
        public string LinkDescription { get; set; }
        public int? LikeCount { get; set; }
        public int? ShareCount { get; set; }
        public int? CommentCount { get; set; }
        public int? LoveCount { get; set; }
        public int? WowCount { get; set; }
        public int? HahaCount { get; set; }
        public int? SadCount { get; set; }
        public int? AngryCount { get; set; }
        public int? ThankfulCount { get; set; }
        public int? CareCount { get; set; }
        
        // each post has a labeling set
        public virtual ICollection<PostLabeling> PostLabeling { get; set; }
    }
}