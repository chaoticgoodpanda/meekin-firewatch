using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Events
{
    public class GetReports
    {
        public class Query : IRequest<Result<List<PostLabelingDto>>>
        {
            
        }
        
        public class Handler : IRequestHandler<Query, Result<List<PostLabelingDto>>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly ILogger _logger;
            private readonly IMapper _mapper;

            public Handler(MeekinFirewatchContext context, ILogger<List> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }

            public async Task<Result<List<PostLabelingDto>>> Handle(Query request, CancellationToken cancellationToken)
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
                    .ProjectTo<PostLabelingDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                

                return Result<List<PostLabelingDto>>.Success(reports);

            
            }
        }
    }
}