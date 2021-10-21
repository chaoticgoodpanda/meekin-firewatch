using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly MeekinFirewatchContext _context;

        public PostsController(MeekinFirewatchContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        
    }
}