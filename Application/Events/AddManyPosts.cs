using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Events
{
    public class AddManyPosts
    {
        public class Command : IRequest
        {
            
        }
        
        public class Handler : IRequestHandler<Command>
        {
            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}