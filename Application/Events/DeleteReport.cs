using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class DeleteReport
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly MeekinFirewatchContext _context;

            public Handler(MeekinFirewatchContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var report = await _context.PostLabelings.FindAsync(request.Id);

                // delete the specific report from the DB
                _context.Remove(report);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}