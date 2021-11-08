using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Events
{
    public class List
    {
        public class Query : IRequest<List<Post>>
        {
            
        }
        
        public class Handler : IRequestHandler<Query, List<Post>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly ILogger _logger;

            public Handler(MeekinFirewatchContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<List<Post>> Handle(Query request, CancellationToken cancellationToken)
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
                var posts = await _context.Posts
                    .Include(m => m.Media)
                    .Include(a => a.Account)
                    .Include(s => s.Statistics)
                    .Include(e => e.ExpandedLinks)
                    .ToListAsync(cancellationToken);

                return posts;

            }
        }
    }
}