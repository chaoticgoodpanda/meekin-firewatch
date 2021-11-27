using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class CreateReport
    {
        public class Command : IRequest
        {
            public PostLabeling PostLabeling { get; set; }
        }
        
        // adding middleware between controller and handler
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.PostLabeling).SetValidator(new ReportValidator());
            }
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
                _context.PostLabelings.Add(request.PostLabeling);

                await _context.SaveChangesAsync();
                
                return Unit.Value;
            }
        }
    }
}