using System;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class VaultController : BaseApiController
    {
        private readonly MeekinFirewatchContext _context;

        public VaultController(MeekinFirewatchContext context)
        {
            _context = context;
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
        public async Task<ActionResult> AddItemToVault(int postId, int quantity)
        {
            // get vault
            var vault = await RetrieveVault();
            
            // if user doesn't have vault, create one
            if (vault == null) vault = CreateVault();

            // get posts to add in vault
            // TODO: see if this postId needs to be changed to the long type Facebook id
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return NotFound();
            
            // add posts to vault
            // TODO: consider whether we need quantity
            vault.AddItem(post, quantity);
            
            // save changes
            return StatusCode(201);
        }
        
        [HttpDelete]
        public async Task<ActionResult> RemoveVaultItem(int postId, int quantity)
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
                .ThenInclude(p => p.Post)
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