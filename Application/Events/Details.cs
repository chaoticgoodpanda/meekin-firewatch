using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Facebook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Events
{
    public class Details
    {
        public class Query : IRequest<Result<PostDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PostDto>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly IMapper _mapper;

            public Handler(MeekinFirewatchContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PostDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts
                    .Include(m => m.Media)
                    .Include(a => a.Account)
                    .Include(s => s.Statistics)
                    .Include(e => e.ExpandedLinks)
                    .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(r => r.GuidId == request.Id);

                return Result<PostDto>.Success(post);

            }
        }
    }
}