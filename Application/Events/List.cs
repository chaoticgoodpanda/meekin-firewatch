using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Facebook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Events
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<PostDto>>>
        {
            public PagingParams Params { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, Result<PagedList<PostDto>>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly ILogger _logger;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(MeekinFirewatchContext context, ILogger<List> logger, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<PagedList<PostDto>>> Handle(Query request, CancellationToken cancellationToken)
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
                var query = _context.Posts
                    .Include(m => m.Media)
                    .Include(a => a.Account)
                    .Include(e => e.ExpandedLinks)
                    .Include(s => s.Statistics)
                    .ThenInclude(act => act.Actual)
                    .ProjectTo<PostDto>(_mapper.ConfigurationProvider,
                        new {currentUsername = _userAccessor.GetUsername()})
                    .AsQueryable();
                

                return Result<PagedList<PostDto>>.Success(
                        await PagedList<PostDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize)
                    );

            }
        }
    }
}