using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Domain.Facebook;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class GetOneReport
    {
        public class Query : IRequest<Result<PostLabeling>>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, Result<PostLabeling>>
        {
            private readonly MeekinFirewatchContext _context;

            public Handler(MeekinFirewatchContext context)
            {
                _context = context;
            }

            public async Task<Result<PostLabeling>> Handle(Query request, CancellationToken cancellationToken)
            {
                var report = await _context.PostLabelings.FindAsync(request.Id);

                // returns null or report in result
                return Result<PostLabeling>.Success(report);
            }
        }
    }
}