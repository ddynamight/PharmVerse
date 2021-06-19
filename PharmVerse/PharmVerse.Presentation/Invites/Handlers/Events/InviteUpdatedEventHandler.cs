using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Invites;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Invites.Handlers.Events
{
     public class InviteUpdatedEventHandler : INotificationHandler<InviteUpdatedEvent>
     {
          private readonly ILogger<InviteUpdatedEventHandler> _logger;

          public InviteUpdatedEventHandler(ILogger<InviteUpdatedEventHandler> logger)
          {
               _logger = logger;
          }

          public Task Handle(InviteUpdatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Invite.DomainEvents;

               _logger.LogInformation($"Invite Updated Event: {domainEvent.GetType().Name} succeeded for Invite with Name: {notification.Invite.Name} and Id: {notification.Invite.Id}");

               return Task.CompletedTask;
          }
     }
}
