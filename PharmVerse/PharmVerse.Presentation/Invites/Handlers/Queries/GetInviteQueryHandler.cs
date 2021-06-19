using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Invites;
using PharmVerse.Presentation.Invites.Models.Results;
using PharmVerse.Presentation.Invites.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Invites.Handlers.Queries
{
     public class GetInviteQueryHandler : IRequestHandler<GetInviteQuery, GetInviteQueryResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public GetInviteQueryHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }

          public async Task<GetInviteQueryResult> Handle(GetInviteQuery request, CancellationToken cancellationToken)
          {
               var invite = await _context.Invites.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               await _mediator.Publish(new InviteAccessedEvent(invite), cancellationToken);
               return _mapper.Map<GetInviteQueryResult>(invite);
          }
     }
}