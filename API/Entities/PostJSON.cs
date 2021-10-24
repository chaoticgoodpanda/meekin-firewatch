using System.Collections.Generic;

namespace API
{
    public class PostJSON
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class ExpandedLink
        {
            public string original { get; set; }
            public string expanded { get; set; }
        }

        public class Medium
        {
            public string type { get; set; }
            public string url { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public string full { get; set; }
        }

        public class Actual
        {
            public int likeCount { get; set; }
            public int shareCount { get; set; }
            public int commentCount { get; set; }
            public int loveCount { get; set; }
            public int wowCount { get; set; }
            public int hahaCount { get; set; }
            public int sadCount { get; set; }
            public int angryCount { get; set; }
            public int thankfulCount { get; set; }
            public int careCount { get; set; }
        }

        public class Expected
        {
            public int likeCount { get; set; }
            public int shareCount { get; set; }
            public int commentCount { get; set; }
            public int loveCount { get; set; }
            public int wowCount { get; set; }
            public int hahaCount { get; set; }
            public int sadCount { get; set; }
            public int angryCount { get; set; }
            public int thankfulCount { get; set; }
            public int careCount { get; set; }
        }

        public class Statistics
        {
            public Actual actual { get; set; }
            public Expected expected { get; set; }
        }

        public class Account
        {
            public int id { get; set; }
            public string name { get; set; }
            public string handle { get; set; }
            public string profileImage { get; set; }
            public int subscriberCount { get; set; }
            public string url { get; set; }
            public string platform { get; set; }
            public string platformId { get; set; }
            public string accountType { get; set; }
            public string pageAdminTopCountry { get; set; }
            public string pageDescription { get; set; }
            public string pageCreatedDate { get; set; }
            public string pageCategory { get; set; }
            public bool verified { get; set; }
        }

        public class Post
        {
            public string platformId { get; set; }
            public string platform { get; set; }
            public string date { get; set; }
            public string updated { get; set; }
            public string type { get; set; }
            public string message { get; set; }
            public List<ExpandedLink> expandedLinks { get; set; }
            public string link { get; set; }
            public string postUrl { get; set; }
            public int subscriberCount { get; set; }
            public double score { get; set; }
            public List<Medium> media { get; set; }
            public Statistics statistics { get; set; }
            public Account account { get; set; }
            public int videoLengthMS { get; set; }
            public string languageCode { get; set; }
            public int legacyId { get; set; }
            public string id { get; set; }
            public string title { get; set; }
            public string caption { get; set; }
            public string description { get; set; }
            public string imageText { get; set; }
            public string liveVideoStatus { get; set; }
        }

        public class Pagination
        {
            public string nextPage { get; set; }
        }

        public class Result
        {
            public List<Post> posts { get; set; }
            public Pagination pagination { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public Result result { get; set; }
        }


    }
}