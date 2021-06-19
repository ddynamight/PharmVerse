using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmVerse.Application.Interfaces.Persistence;
using PharmVerse.Domain.Events.Invites;
using PharmVerse.Presentation.Invites.Commands;
using PharmVerse.Presentation.Invites.Models.Results;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Invites.Handlers.Commands
{
     public class UpdateInviteCommandHandler : IRequestHandler<UpdateInviteCommand, UpdateInviteCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public UpdateInviteCommandHandler(IAppDbContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }

          public async Task<UpdateInviteCommandResult> Handle(UpdateInviteCommand request, CancellationToken cancellationToken)
          {
               var inviteFromDb = await _context.Invites.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);

               var invite = _mapper.Map(request, inviteFromDb);
               invite.AddDomainEvent(new InviteUpdatedEvent(invite));

               _context.Invites.Attach(invite);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new InviteUpdatedEvent(invite), cancellationToken);

               return _mapper.Map(invite, new UpdateInviteCommandResult());
          }
     }
}