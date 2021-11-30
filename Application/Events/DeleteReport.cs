using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class DeleteReport
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly MeekinFirewatchContext _context;

            public Handler(MeekinFirewatchContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var report = await _context.PostLabelings.FindAsync(request.Id);

                // Unit cannot return null, so we just need to return null and edit the BaseApiController
                if (report == null) return null;

                // delete the specific report from the DB
                _context.Remove(report);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the report.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}