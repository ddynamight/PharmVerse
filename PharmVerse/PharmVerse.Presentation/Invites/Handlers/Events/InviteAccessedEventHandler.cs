using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Invites;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Invites.Handlers.Events
{
     public class InviteAccessedEventHandler : INotificationHandler<InviteAccessedEvent>
     {
          private readonly ILogger<InviteAccessedEventHandler> _logger;

          public InviteAccessedEventHandler(ILogger<InviteAccessedEventHandler> logger)
          {
               _logger = logger;
          }

          public Task Handle(InviteAccessedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Invite.DomainEvents;

               _logger.LogInformation($"Invite Accessed Event: {domainEvent.GetType().Name} succeeded for Invite with Name: {notification.Invite.Name} and Id: {notification.Invite.Id}");

               return Task.CompletedTask;
          }
     }
}
