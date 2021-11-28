using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Events
{
    public class GetReports
    {
        public class Query : IRequest<Result<List<PostLabeling>>>
        {
            
        }
        
        public class Handler : IRequestHandler<Query, Result<List<PostLabeling>>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly ILogger _logger;

            public Handler(MeekinFirewatchContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Result<List<PostLabeling>>> Handle(Query request, CancellationToken cancellationToken)
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
                var reports = Result<List<PostLabeling>>.Success(await _context.PostLabelings
                    // .Include(j => j.Justifications)
                    // .Include(c => c.Country)
                    // .Include(i => i.Intent)
                    // .Include(s => s.Speaker)
                    .ToListAsync(cancellationToken));

                return reports;

            
            }
        }
    }
}