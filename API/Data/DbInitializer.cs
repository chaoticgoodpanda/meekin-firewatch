using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    // with a static class, don't need to create new instance of the class
    public static class DbInitializer
    {
        public static void Initialize(MeekinFirewatchContext context)
        {
            // if it's already populated, exit this method
            if (context.Posts.Any()) return;

            var posts = new List<Post>()
            {
                new Post(new List<PostLabeling>())
                {
                    AccountName = "Donald Trump Fake",
                    PostContent = "I love drinking coffeve",
                    ProfileImage = "/images/posts/donald.png",
                    AccountType = "page",
                    AccountCountry = "US",
                    PostUrl = "https://www.facebook.com/DonaldTrump/posts/10166091482665725?__cft__[0]=AZXyUYTB1f0B0jlYpRi0oBBU0fC8gOMevY0EEfcis0TFMWK9JfJD2Oee0ve4ENTRdd-CtZgrmVUIrBMgjcN3R2NW2qgdo4FXFuVEkGVkWwKry417SMa0oLtW-DY9G-zAgSndoCI-5FfTi-LiwfrnXCC-&__tn__=%2CO%2CP-R",
                    SubscriberCount = 57836723,
                    Score = 3978473.3,
                    LikeCount = 7263,
                    
                }
            };

            // iterate over each provided post and add to the DbSet Posts
            foreach (var post in posts)
            {
                context.Posts.Add(post);
            }

            // save changes to database
            context.SaveChanges();
        }
    }
}