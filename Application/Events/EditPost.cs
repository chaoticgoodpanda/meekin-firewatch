using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class EditPost
    {
        public class Command : IRequest
        {
            public string PlatformId { get; set; }
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
                var post = await _context.Posts.FindAsync(request.PlatformId);
                return Unit.Value;
            }
        }
    }
}