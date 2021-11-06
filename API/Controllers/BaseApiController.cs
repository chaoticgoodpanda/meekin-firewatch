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
        
        
    }
}