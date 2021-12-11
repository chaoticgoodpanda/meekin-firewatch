using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using Domain.Facebook;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            private readonly IUserAccessor _userAccessor;

            public Handler(MeekinFirewatchContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // gives us access to our user object
                // can create a new reporter based on information
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var reporter = new ReportReporter
                {
                    User = user,
                    Report = request.PostLabeling,
                    IsAuthor = true
                };
                
                request.PostLabeling.Reporters.Add(reporter);
                
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