using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using API.Crowdtangle;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
        public async Task<ActionResult> GetFacebookPosts(
            string _fbApiKey
            
            
            
            
            )
        {
            var Url = string.Format("posts?");
            var result = await CrowdtangleApi<List<Post>>.Get(Url);
        }
    }
}