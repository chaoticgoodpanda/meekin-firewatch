using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected string baseUrl = "https://api.crowdtangle.com/";
        protected string postsUrl = "posts?token=";
        protected string count = "&count=100";

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();
        
        // method to validate each controller method
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null) return Ok(result.Value);

            if (result.IsSuccess && result.Value == null) return NotFound();

            return BadRequest(result.Error);
        }
    }
}