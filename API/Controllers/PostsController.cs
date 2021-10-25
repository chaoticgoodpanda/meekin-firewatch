using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using API.Crowdtangle;
using API.Data;
using API.Facebook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly MeekinFirewatchContext _context;
        private readonly string _fbApiKey;
        private readonly string _instaApiKey;
        private readonly string _redditApiKey;

        public PostsController(MeekinFirewatchContext context, IConfiguration config)
        {
            _context = context;
            _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
            _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
            _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;

        }

        [HttpGet]
        public ActionResult<List<Post>> GetFacebookPosts()
        {
            // var Url = string.Format("posts?");
            // var result = await CrowdtangleApi<List<Post>>.Get(Url);

            string baseUrl = "https://api.crowdtangle.com/";
            string postsUrl = "posts?token=";

            // // populate a list of posts
            // var posts = _context.Posts.ToList();
            
            // create a new RestSharp HttpClient
            IRestClient client = new RestClient();
            Uri getUri = new Uri(baseUrl + postsUrl + _fbApiKey);
            IRestRequest request = new RestRequest(getUri);
            request.AddHeader("Accept", "application/json");

            // deserialize the JSON response content
            // IRestResponse<List<Post>> restResponse = restClient.Get<List<Post>>(restRequest);
            var response = client.Get<Root>(request);

            // if error, print stack trace
            if (!response.IsSuccessful) Console.WriteLine("Stack Trace: " + response.ErrorException); 

            // else, return the data from the restResponse request.
            return Ok(response.Data);


        }
    }
}