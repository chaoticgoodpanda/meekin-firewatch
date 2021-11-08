using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Facebook;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class GetOneReport
    {
        public class Query : IRequest<PostLabeling>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, PostLabeling>
        {
            private readonly MeekinFirewatchContext _context;

            public Handler(MeekinFirewatchContext context)
            {
                _context = context;
            }

            public async Task<PostLabeling> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.PostLabelings.FindAsync(request.Id);
            }
        }
    }
}