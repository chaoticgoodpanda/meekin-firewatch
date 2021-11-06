using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Events
{
    public class List
    {
        public class Query : IRequest<List<Post>>
        {
            
        }
        
        public class Handler : IRequestHandler<Query, List<Post>>
        {
            private readonly MeekinFirewatchContext _context;

            public Handler(MeekinFirewatchContext context)
            {
                _context = context;
            }

            public async Task<List<Post>> Handle(Query request, CancellationToken cancellationToken)
            {
                // returns a list of posts -- if there are any issues with this with the JSON <Root> structure
                return await _context.Posts.ToListAsync();
            }
        }
    }
}