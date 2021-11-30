using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain.Facebook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Events
{
    public class List
    {
        public class Query : IRequest<Result<List<Post>>>
        {
            
        }
        
        public class Handler : IRequestHandler<Query, Result<List<Post>>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly ILogger _logger;

            public Handler(MeekinFirewatchContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Result<List<Post>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    // offer feature where user can cancel request 
                    // need to add to front end later
                    cancellationToken.ThrowIfCancellationRequested();
                    // returns a list of posts -- if there are any issues with this with the JSON <Root> structure
                    _logger.LogInformation("Posts have been retrieved from database.");

                }
                catch (Exception e) when (e is TaskCanceledException)
                {
                    _logger.LogInformation("Posts retrieval was canceled by user.");
                }

                // eagerly load the nested arrays
                var posts = Result<List<Post>>.Success(await _context.Posts
                    .Include(m => m.Media)
                    .Include(a => a.Account)
                    .Include(e => e.ExpandedLinks)
                    .Include(s => s.Statistics)
                    .ThenInclude(act => act.Actual)
                    .ToListAsync(cancellationToken));

                return posts;

            }
        }
    }
}