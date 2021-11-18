using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Events
{
    public class GetReportsForOnePost
    {
        public class Query : IRequest<List<PostLabeling>>
        {
            public Guid PostGuidId { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, List<PostLabeling>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly ILogger _logger;

            public Handler(MeekinFirewatchContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<List<PostLabeling>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    // offer feature where user can cancel request 
                    // need to add to front end later
                    cancellationToken.ThrowIfCancellationRequested();
                    // returns a list of posts -- if there are any issues with this with the JSON <Root> structure
                    _logger.LogInformation("Reports have been retrieved from database.");

                }
                catch (Exception e) when (e is TaskCanceledException)
                {
                    _logger.LogInformation("Posts retrieval was canceled by user.");
                }

                // eagerly load the nested arrays
                var reports = await _context.PostLabelings
                    .Where(o => o.FacebookGuid == request.PostGuidId).ToListAsync(cancellationToken);

                return reports;

            
            }
        }
    }
}