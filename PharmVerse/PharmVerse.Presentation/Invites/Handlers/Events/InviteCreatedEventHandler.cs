using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Domain.Events.Invites;
using System.Threading;
using System.Threading.Tasks;
using PharmVerse.Application.Interfaces.Infrastructure;

namespace PharmVerse.Presentation.Invites.Handlers.Events
{
     public class InviteCreatedEventHandler : INotificationHandler<InviteCreatedEvent>
     {
          private readonly ILogger<InviteCreatedEventHandler> _logger;
          private readonly IEmailService _emailService;
          private readonly ISmsService _smsService;


          public InviteCreatedEventHandler(ILogger<InviteCreatedEventHandler> logger, IEmailService emailService, ISmsService smsService)
          {
               _logger = logger;
               _emailService = emailService;
               _smsService = smsService;
          }

          public Task Handle(InviteCreatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Invite.DomainEvents;

               _logger.LogInformation($"Invite Created Event: {domainEvent.GetType().Name} succeeded for Invite with Name: {notification.Invite.Name} and Id: {notification.Invite.Id}");

               //string emailMessage = "";
               //string smsMessage = "";

               //_emailService.Equals(notification.Invite.Email);
               //_smsService.Equals(notification.Invite.Phone);



               return Task.CompletedTask;
          }
     }
}
