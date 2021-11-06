using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Events;
using Domain.Facebook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace API.Controllers
{
    public class PostsController : BaseApiController
    {
        private readonly string _fbApiKey;
        private readonly string _instaApiKey;
        private readonly string _redditApiKey;
        private string baseUrl = "https://api.crowdtangle.com/";
        private string postsUrl = "posts?token=";
        private string count = "&count=100";
        

        public PostsController(IConfiguration config)
        {
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
            return await Mediator.Send(new List.Query());

        }
        
        //get a specific post stored locally on the SQL DB
        [HttpGet("local/{id}")]
        public async Task<ActionResult<Post>> GetLocalPost(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        
        
        // add a post from Crowdtangle to local DB
        [HttpPost("{id}")]
        public async Task<IActionResult> AddPost(string id)
        {

            return Ok(await Mediator.Send(new AddPost.Command { Id = id }));
        }
    }
}