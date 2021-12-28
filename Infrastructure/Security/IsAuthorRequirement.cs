using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Infrastructure.Security
{
    public class IsAuthorRequirement : IAuthorizationRequirement
    {
        
    }

    public class IsHostRequirementHandler : AuthorizationHandler<IsAuthorRequirement>
    {
        private readonly MeekinFirewatchContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsHostRequirementHandler(MeekinFirewatchContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext authContext, IsAuthorRequirement requirement)
        {
            // retrieve the user's ID b/c reports table is made up of combo of user id and report id
            // query is more efficient if we just try to find report by using primary key
            var userId = authContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // user doesn't meet auth requirement
            if (userId == null) return Task.CompletedTask;
            
            // gives report ID from route parameters
            var reportId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
                .SingleOrDefault(x => x.Key == "id").Value?.ToString());

            // should contain reportreporter object
            var reporter = _dbContext.ReportReporters.FindAsync(userId, reportId).Result;

            if (reporter == null) return Task.CompletedTask;
            
            // if the reporter is the author, then the auth policy succeeds
            if (reporter.IsAuthor) authContext.Succeed(requirement);

            // returning this at this point and context succeed flag is set then user is authorized to go ahead and edit the report
            return Task.CompletedTask;
        }
    }
}