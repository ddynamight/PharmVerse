using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using PharmVerse.Domain.Patients.Patients;

namespace PharmVerse.Presentation.Patients.Handlers.Events
{
    public class PatientAccessedEventHandler : INotificationHandler<PatientAccessedEvent>
    {
        private readonly ILogger<PatientAccessedEventHandler> _logger;

        public PatientAccessedEventHandler(ILogger<PatientAccessedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(PatientAccessedEvent notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.Patient.DomainEvents;
            _logger.LogInformation($"Patient Accessed Event {domainEvent.GetType().Name} succeeded for patient with name " +
                $"{notification.Patient.FirstName} {notification.Patient.LastName} and Id {notification.Patient.Id}");
            return Task.CompletedTask;
        }
    }
}
