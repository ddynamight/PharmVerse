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
     public class DeleteInviteCommandHandler : IRequestHandler<DeleteInviteCommand, DeleteInviteCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMediator _mediator;

          public DeleteInviteCommandHandler(IAppDbContext context, IMediator mediator)
          {
               _context = context;
               _mediator = mediator;
          }

          public async Task<DeleteInviteCommandResult> Handle(DeleteInviteCommand request, CancellationToken cancellationToken)
          {
               var invite = await _context.Invites.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               invite.AddDomainEvent(new InviteDeletedEvent(invite));
               _context.Invites.Remove(invite);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new InviteDeletedEvent(invite), cancellationToken);

               return new DeleteInviteCommandResult
               {
                    Id = request.Id,
                    IsDeleted = true,
                    Message = $"Invite with Id {request} is deleted successfully"
               };
          }
     }
}