using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;
using RestSharp;

namespace API.Controllers
{
    public class PostsController : BaseApiController
    {
        private readonly MeekinFirewatchContext _context;
        private readonly string _fbApiKey;
        private readonly string _instaApiKey;
        private readonly string _redditApiKey;
        private string baseUrl = "https://api.crowdtangle.com/";
        private string postsUrl = "posts?token=";
        private string count = "&count=20";
        

        public PostsController(MeekinFirewatchContext context, IConfiguration config)
        {
            _context = context;
            _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
            _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
            _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;

        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetFacebookPosts()
        {

            // create a new RestSharp HttpClient
            IRestClient client = new RestClient();
            Uri getUri = new Uri(baseUrl + postsUrl + _fbApiKey + count);
            IRestRequest request = new RestRequest(getUri);
            // cancellation RestSharp token for async requests
            var cancellationTokenSource = new CancellationTokenSource();
            request.AddHeader("Accept", "application/json");
            
            var response =  await client.ExecuteAsync<Root>(request, cancellationTokenSource.Token);

            // if error, print stack trace
            if (!response.IsSuccessful) Console.WriteLine("Stack Trace: " + response.ErrorException); 

            // else, return the data from the restResponse request.
            return Ok(response.Data.Result.Posts);


        }

        // get the posts stored locally on the SQL DB
        [HttpGet("local")]
        public async Task<ActionResult<List<Post>>> GetLocalPosts()
        {
            return await _context.Posts.ToListAsync();
            
        }

        // TODO: figure out how to sync the [number]_[number] format in the right string format for CT
        // id is string because Facebook stores post ids in this format: 155869377766434_6112776065409039
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetFacebookPost(string id)
        {
            // specific post ID segment of URL
            var onePost = string.Format("post/{0}?token=", id);
            
            string[] idTokens = id.Split('_');
            var number1 = Int64.Parse(idTokens[0]);
            var number2 = Int64.Parse(idTokens[1]);

            IRestClient client = new RestClient();
            Uri getUri = new Uri(baseUrl + onePost + _fbApiKey);
            IRestRequest request = new RestRequest(getUri);
            request.AddHeader("Accept", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            // request.AddUrlSegment("id", number1 + "_" + number2);

            var response = await client.ExecuteAsync<Root>(request, cancellationTokenSource.Token);
            
            // if error, print stack trace
            if (!response.IsSuccessful) Console.WriteLine("Stack Trace: " + response.ErrorException); 

            // else, return the data from the restResponse request.
            return Ok(response.Data);
        }
    }
}