using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Invites;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Invites.Handlers.Events
{
     public class InviteDeletedEventHandler : INotificationHandler<InviteDeletedEvent>
     {
          private readonly ILogger<InviteDeletedEventHandler> _logger;

          public InviteDeletedEventHandler(ILogger<InviteDeletedEventHandler> logger)
          {
               _logger = logger;
          }

          public Task Handle(InviteDeletedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Invite.DomainEvents;

               _logger.LogInformation($"Invite Deleted Event: {domainEvent.GetType().Name} succeeded for Invite with Name: {notification.Invite.Name} and Id: {notification.Invite.Id}");

               return Task.CompletedTask;
          }

     }
}
