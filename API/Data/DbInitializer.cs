using System.Collections.Generic;
using System.Linq;
using API.Facebook;

namespace API.Data
{
    // with a static class, don't need to create new instance of the class
    public static class DbInitializer
    {
        public static void Initialize(MeekinFirewatchContext context)
        {
            // if it's already populated, exit this method
            if (context.Posts.Any()) return;

            var posts = new List<Facebook.Post>()
            {
                new Facebook.Post()
                {
                    PostUrl = "https://www.facebook.com/155869377766434/posts/6112776065409039",
                    PlatformId = "155869377766434_6112776065409039",
                    Platform = "Facebook",
                    Title = "Autopsy of Brian Laundrie's remains came back inconclusive, attorney says",
                    SubscriberCount = 10753023,
                    LanguageCode = "en",
                    Caption = "nbcnews.com"
                    
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