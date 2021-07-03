using MediatR;
using Microsoft.Extensions.Logging;
using PharmVerse.Application.Interfaces.Infrastructure;
using PharmVerse.Domain.Events.Patients;
using System.Threading;
using System.Threading.Tasks;

namespace PharmVerse.Presentation.Patients.Handlers.Events
{
     public class PatientCreatedEventHandler : INotificationHandler<PatientCreatedEvent>
     {
          private readonly ILogger<PatientAccessedEventHandler> _logger;
          private readonly IEmailService _emailService;
          private readonly ISmsService _smsService;

          public PatientCreatedEventHandler(ILogger<PatientAccessedEventHandler> logger, IEmailService emailService, ISmsService smsService)
          {
               _logger = logger;
               _emailService = emailService;
               _smsService = smsService;
          }

          public Task Handle(PatientCreatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Patient.DomainEvents;
               _logger.LogInformation($"Patient Created Event {domainEvent.GetType().Name} succeeded  for patient with name " +
                   $"{notification.Patient.FirstName} {notification.Patient.LastName} and Id {notification.Patient.Id}");

               return Task.CompletedTask;
          }
     }
}
