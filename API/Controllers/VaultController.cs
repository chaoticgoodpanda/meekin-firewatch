using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace API.Controllers
{
    public class VaultController : BaseApiController
    {
        private readonly MeekinFirewatchContext _context;
        private readonly string _fbApiKey;
        private readonly string _instaApiKey;
        private readonly string _redditApiKey;
        private string baseUrl = "https://api.crowdtangle.com/";

        public VaultController(MeekinFirewatchContext context, IConfiguration config)
        {
            _context = context;
            _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
            _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
            _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;
        }

        [HttpGet]
        public async Task<ActionResult<Vault>> GetVault()
        {
            // gives us the post, info of post in vault
            var vault = await RetrieveVault();

            if (vault == null) return NotFound();

            return vault;
        }

        // TODO: write code so user has option to create multiple vaults of different categories (e.g. kinds of speech, countries)
        [HttpPost]
        public async Task<ActionResult> AddItemToVault(string postId, int quantity)
        {
            // get vault
            var vault = await RetrieveVault();
            
            // if user doesn't have vault, create one
            if (vault == null) vault = CreateVault();

            // get posts to add in vault
            // this code only applies once write posts to DB
            // var post = await _context.Posts.FindAsync(postId);
            
            //Crowdtangle API call to post
            // specific post ID segment of URL
            var onePost = string.Format("post/{0}?token=", postId);
            
            string[] idTokens = postId.Split('_');
            var number1 = Int64.Parse(idTokens[0]);
            var number2 = Int64.Parse(idTokens[1]);

            IRestClient client = new RestClient();
            Uri getUri = new Uri(baseUrl + onePost + _fbApiKey);
            IRestRequest request = new RestRequest(getUri);
            request.AddHeader("Accept", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            // request.AddUrlSegment("id", number1 + "_" + number2);

            var response = await client.ExecuteAsync<Root>(request, cancellationTokenSource.Token);
            var data = response.Data.Result.Posts;


            // if error, print stack trace
            if (!response.IsSuccessful) Console.WriteLine("Stack Trace: " + response.ErrorException); 
            if (data == null) return NotFound();
            
            // add posts to vault
            vault.AddItem(data, quantity);
            
            // save changes
            var result = await _context.SaveChangesAsync() > 0;
            
            if (result) return StatusCode(201);

            return BadRequest(new ProblemDetails { Title = "Problem saving item to vault." });


        }
        
        [HttpDelete]
        public async Task<ActionResult> RemoveVaultItem(string postId, int quantity)
        {
            // get vault
            
            // remove post or reduce posts
            
            // save changes
            return Ok();
        }
        
        // helper method
        private async Task<Vault> RetrieveVault()
        {
            return await _context.Vaults
                .Include(i => i.Items)
                .ThenInclude(p => p.Posts)
                .FirstOrDefaultAsync(x => x.UserId == Request.Cookies["userId"]);
            
        }
        
        // creates a new vault
        // TODO: write code where user can create multiple vaults and select vaults by category name
        private Vault CreateVault()
        {
            // creates very unique id for user to assign to new vault
            var userId = Guid.NewGuid().ToString();
            // probably don't need cookie options to expires since it's a vault, not a basket, so commented out
            var cookieOptions = new CookieOptions{IsEssential = true}; //Expires = DateTime.Now.AddDays(30)};
            Response.Cookies.Append("userId", userId, cookieOptions);
            
            // create a new vault, only need to add userId when creating a new vault
            var vault = new Vault { UserId = userId };
            _context.Vaults.Add(vault);

            return vault;
        }

    }
}