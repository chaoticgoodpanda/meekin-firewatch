using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Facebook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Events
{
    public class GetOneReport
    {
        public class Query : IRequest<Result<PostLabelingDto>>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, Result<PostLabelingDto>>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly IMapper _mapper;

            public Handler(MeekinFirewatchContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PostLabelingDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var report = await _context.PostLabelings
                    .ProjectTo<PostLabelingDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                // returns null or report in result
                return Result<PostLabelingDto>.Success(report);
            }
        }
    }
}