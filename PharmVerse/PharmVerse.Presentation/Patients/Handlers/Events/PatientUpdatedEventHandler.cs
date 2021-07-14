using MediatR;
using Microsoft.Extensions.Logging;
<<<<<<< HEAD
=======
using PharmVerse.Domain.Events.Patients;
>>>>>>> main
using System.Threading;
using System.Threading.Tasks;
using PharmVerse.Domain.Patients.Patients;

namespace PharmVerse.Presentation.Patients.Handlers.Events
{
     public class PatientUpdatedEventHandler : INotificationHandler<PatientUpdatedEvent>
     {
          private readonly ILogger<PatientAccessedEventHandler> _logger;

          public PatientUpdatedEventHandler(ILogger<PatientAccessedEventHandler> logger)
          {
               _logger = logger;
          }

          public Task Handle(PatientUpdatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Patient.DomainEvents;
               _logger.LogInformation($"Patient Update Event {domainEvent.GetType().Name} succeeded  for patient with name " +
                   $"{notification.Patient.FirstName} {notification.Patient.LastName} and Id {notification.Patient.Id}");

               return Task.CompletedTask;
          }
     }
}
