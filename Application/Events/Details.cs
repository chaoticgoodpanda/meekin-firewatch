using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Events
{
    public class Details
    {
        public class Query : IRequest<Post>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Post>
        {
            private readonly MeekinFirewatchContext _context;

            public Handler(MeekinFirewatchContext context)
            {
                _context = context;
            }

            public async Task<Post> Handle(Query request, CancellationToken cancellationToken)
            {
                return _context.Posts
                    .Include(m => m.Media)
                    .Include(a => a.Account)
                    .Include(s => s.Statistics)
                    .Include(e => e.ExpandedLinks)
                    .Single(r => r.GuidId == request.Id);

            }
        }
    }
}