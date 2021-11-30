using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class CreateReport
    {
        // Unit from Mediatr because we are not returning anything
        public class Command : IRequest<Result<Unit>>
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

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly MeekinFirewatchContext _context;

            public Handler(MeekinFirewatchContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.PostLabelings.Add(request.PostLabeling);

                // SaveChangesAsync actually returns an int, containing the # of result entries written to DB.
                // so if none written to DB returns 0 (false)
                var result = await _context.SaveChangesAsync() > 0;

                // returns a 400 Bad Request
                if (!result) return Result<Unit>.Failure("Failed to create report.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}