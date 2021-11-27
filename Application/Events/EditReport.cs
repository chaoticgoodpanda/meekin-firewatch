using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Events
{
    public class EditReport
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
            private readonly IMapper _mapper;

            public Handler(MeekinFirewatchContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var report = await _context.PostLabelings.FindAsync(request.PostLabeling.Id);
                    
                // update whatever fields are provided using AutoMapper on the DB side    
                _mapper.Map(request.PostLabeling, report);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}