using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Invites;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Invites.Handlers.Events
{
     public class AllInviteAccessedEventHandler : INotificationHandler<AllInviteAccessedEvent>
     {
          private readonly ILogger<AllInviteAccessedEventHandler> _logger;

          public AllInviteAccessedEventHandler(ILogger<AllInviteAccessedEventHandler> logger)
          {
               _logger = logger;
          }

          public Task Handle(AllInviteAccessedEvent notification, CancellationToken cancellationToken)
          {
               _logger.LogInformation($"All Invite Accessed Event: {notification.Invites.Capacity} Invites accessed successfully");

               return Task.CompletedTask;
          }
     }
}