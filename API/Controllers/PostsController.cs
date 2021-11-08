using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Events;
using Domain;
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

        public PostsController(IConfiguration config)
        {
            _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
            _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
            _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;

        }

        [HttpPost]
        public async Task<IActionResult> GetFacebookPosts()
        {

            return Ok(await Mediator.Send(new AddManyPosts.Command()));
            
        }

        // get the posts stored locally on the SQL DB
        // CancellationToken enables cancel possibility if taking too long
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetLocalPosts(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new List.Query(), cancellationToken);

        }
        
        //get a specific post stored locally on the SQL DB
        [HttpGet("{id}")]
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

        // creates a new report for post, with Rabat labels
        [HttpPost("report")]
        public async Task<IActionResult> CreateReport(PostLabeling postLabeling)
        {
            return Ok(await Mediator.Send(new CreateReport.Command { PostLabeling = postLabeling }));
        }
        
        // updates a report
        [HttpPut("report/{id}")]
        public async Task<IActionResult> EditReport(Guid id, PostLabeling postLabeling)
        {
            postLabeling.Id = id;
            return Ok(await Mediator.Send(new EditReport.Command { PostLabeling = postLabeling }));
        }
        
        //get a specific report stored locally on the SQL DB
        [HttpGet("report/{id}")]
        public async Task<ActionResult<PostLabeling>> GetReport(Guid id)
        {
            return await Mediator.Send(new GetOneReport.Query{Id = id});
        }

        // delete a specific report
        [HttpDelete("report/{id}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteReport.Command { Id = id }));
        }
    }
}