using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class EditReport
    {
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
            private readonly IMapper _mapper;

            public Handler(MeekinFirewatchContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var report = await _context.PostLabelings.FindAsync(request.PostLabeling.Id);

                if (report == null) return null;
                    
                // update whatever fields are provided using AutoMapper on the DB side    
                _mapper.Map(request.PostLabeling, report);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to edit report.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}